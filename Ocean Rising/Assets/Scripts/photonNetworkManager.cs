using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class photonNetworkManager : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server . . .");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Server");
        base.OnConnectedToMaster();
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 10;
        room.IsVisible = true;
        room.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Ocean 1", room, TypedLobby.Default);
    }

    public override void OnJoinedRoom(){ 
        Debug.Log("Joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player player){
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(player);
    }
} 
