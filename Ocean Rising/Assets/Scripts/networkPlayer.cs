using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using FMODUnity;


public class networkPlayer : MonoBehaviour
{
    public Transform head;
    public GameObject leftHand;
    public GameObject rightHand;
    private PhotonView photonView;
    private StudioListener listener;
    public GameObject VRcam;
    public GameObject input;
    public GameObject snap;
    private bool deleted = false;


    void Start(){
        photonView = GetComponent<PhotonView>();
        listener = GetComponent<StudioListener>();
        
    }
    void Update(){
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            if(deleted == false){
                MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
                foreach(MonoBehaviour c in comps)
                {
                    c.enabled = false;
                }
                VRcam.SetActive(false);
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
