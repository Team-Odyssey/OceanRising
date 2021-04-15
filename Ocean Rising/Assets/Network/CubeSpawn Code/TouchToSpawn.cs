using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToSpawn : MonoBehaviour
{
    public GameObject prefab, prefab2;

    public Camera mainCamera;

    [SerializeField] float spawnZPosition;
    
    private NetworkManager networkManager;
    private MessageQueue msgQueue;

    void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_SPAWNCUBE, OnResponseSpawnCube);

    }

    private void OnDestroy()
    {
        msgQueue.RemoveCallback(Constants.SMSG_SPAWNCUBE);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPos =
                mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            touchPos.z = spawnZPosition;
            Instantiate(prefab, touchPos, Quaternion.identity);
            //networkManager.SendSpawnCubeRequest(touchPos.x, touchPos.y);
        }
    }
    
    private void OnResponseSpawnCube(ExtendedEventArgs eventargs)
    {
        ResponseSpawnCubeArgs args = eventargs as ResponseSpawnCubeArgs; // C# conversion. Takes eventargs and turns it into responseSpawnCubeArgs type
		
        if (args.user_id == Constants.OP_ID)
        {
            Vector3 touchPos = new Vector3(args.x, args.y, spawnZPosition);
            Instantiate(prefab2, touchPos, Quaternion.identity);
        }
    }
}
