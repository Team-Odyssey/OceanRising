﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class SwimmingController : MonoBehaviour
{
    [SerializeField] private float swimmingForce;
    [SerializeField] private float resistanceForce;
    [SerializeField] private float deadZone;
    [SerializeField] private Transform trackingSpace;
    
    [SerializeField] public SteamVR_Action_Boolean rightHandTrigger;
    [SerializeField] public SteamVR_Action_Boolean leftHandTrigger;
    [SerializeField] public SteamVR_Action_Pose rightHandPose;
    [SerializeField] public SteamVR_Action_Pose leftHandPose;
    public GameObject swimSound;

    private new Rigidbody rigidbody;
    private Vector3 currentDirection;
    private float currentWaitTime;
    private float interval;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
                swimSound.SetActive(true);
                AddSwimmingForce(localVelocity);
                currentWaitTime = 0f;
                StartCoroutine (stopSound());
            }
        }
        ApplyReststanceForce();
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
    IEnumerator stopSound(){
        yield return new WaitForSeconds(.5f);
        swimSound.SetActive(false);
    }
}