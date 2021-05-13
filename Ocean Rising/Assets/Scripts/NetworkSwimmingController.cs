using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody))]
public class NetworkSwimmingController : MonoBehaviour
{
    [SerializeField] private float swimmingForce;
    [SerializeField] private float resistanceForce;
    [SerializeField] private float deadZone;
    [SerializeField] private Transform trackingSpace;
    
    [SerializeField] public SteamVR_Action_Boolean rightHandTrigger;
    [SerializeField] public SteamVR_Action_Boolean leftHandTrigger;
    [SerializeField] public SteamVR_Action_Pose rightHandPose;
    [SerializeField] public SteamVR_Action_Pose leftHandPose;

    private new Rigidbody rigidbody;
    private Vector3 currentDirection;
    private float currentWaitTime;
    private float interval;
    private PhotonView photonView;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }else{
            // bool rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
            bool rightButtonPressed = rightHandTrigger.state; 
            // bool leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);
            bool leftButtonPressed = leftHandTrigger.state;

            currentWaitTime += Time.deltaTime;
            
            if (rightButtonPressed && leftButtonPressed)
            {
                // Vector3 leftHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                Vector3 leftHandDirection = leftHandPose.velocity;
                //Vector3 rightHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                Vector3 rightHandDirection = rightHandPose.velocity;
                
                Vector3 localVelocity = leftHandDirection + rightHandDirection;
                localVelocity *= -1f;
                var squaredDeadzone = deadZone * deadZone;
                if (localVelocity.sqrMagnitude > squaredDeadzone && currentWaitTime > interval)
                {
                    AddSwimmingForce(localVelocity);
                    currentWaitTime = 0f;
                }
            }
            ApplyReststanceForce();
        }
    }

    private void ApplyReststanceForce()
    {
        if (rigidbody.velocity.sqrMagnitude > 0.01f && currentDirection != Vector3.zero)
        {
            rigidbody.AddForce(-rigidbody.velocity * resistanceForce, ForceMode.Acceleration);
        }
        else
        {
            currentDirection = Vector3.zero;
        }
    }

    private void AddSwimmingForce(Vector3 localVelocity)
    {
        Vector3 worldSpaceVelocity = trackingSpace.TransformDirection(localVelocity); // transforms from world space to local space
        rigidbody.AddForce(worldSpaceVelocity * swimmingForce, ForceMode.Acceleration);
        currentDirection = worldSpaceVelocity.normalized;
    }
}