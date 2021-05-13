using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Photon.Pun;

public class NetworkController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 2;

    public bool showController = false;
    private PhotonView photonView;

    // Update is called once per frame
    void Start(){
        photonView = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }else{
            foreach (var hand in Player.instance.hands){
                if(showController){ 
                    hand.ShowController();
                    hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
                }
                else{
                    hand.ShowController();
                    hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
                }

            }
        }
        

        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
    }
}