using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using FMODUnity;
using UnityEngine.SpatialTracking;


public class networkPlayer : MonoBehaviour
{
    public Transform head;
    public GameObject leftHand;
    public GameObject rightHand;
    private PhotonView photonView;
    private StudioListener listener;
    public GameObject vrCam;
    public Camera camcam;
    public GameObject canvas;
    public GameObject oceanOne;
    public GameObject oceanTwo;
    public GameObject input;
    public GameObject snap;
    private bool deleted = false;


    void Start(){
        photonView = GetComponent<PhotonView>();
        listener = GetComponent<StudioListener>();
        
    }
    void Update(){
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if(deleted == false){
                MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
                foreach(MonoBehaviour c in comps)
                {
                    c.enabled = false;
                }
                MonoBehaviour[] cam = vrCam.GetComponents<MonoBehaviour>();
                foreach(MonoBehaviour d in cam)
                {
                    if(d.name != "Photon Transorm View" || d.name != "Tracked Pose Driver")
                        d.enabled = false;
                }
                camcam.enabled = false;
                vrCam.GetComponent<PhotonTransformView>().enabled = true;
                vrCam.GetComponent<TrackedPoseDriver>().enabled = true;
                GetComponent<PhotonTransformView>().enabled = true;
                canvas.SetActive(false);
                oceanOne.SetActive(false);
                oceanTwo.SetActive(false);
                rightHand.gameObject.SetActive(false);
                leftHand.gameObject.SetActive(false);
                input.gameObject.SetActive(false);
                snap.gameObject.SetActive(false);
                deleted = true;
            }
                
            return;
        }
        // if(photonView.IsMine){
        //     rightHand.gameObject.SetActive(false);
        //     leftHand.gameObject.SetActive(false);
        //     head.gameObject.SetActive(false);

        //     MapPosition(head, XRNode.Head);
        //     MapPosition(leftHand, XRNode.LeftHand);
        //     MapPosition(rightHand, XRNode.RightHand);

        // }
        
    }
    // void MapPosition(Transform target, XRNode node){
    //     InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
    //     InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);
    //     target.position = position;
    //     target.rotation = rotation;
    // }
}
