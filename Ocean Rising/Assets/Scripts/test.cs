using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class test : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    public SteamVR_Action_Single action;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(action.axis.ToString("N5"));
        player.position += camera.forward * action.axis * speed;
    }
}
