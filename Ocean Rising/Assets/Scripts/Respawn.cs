using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform respawnPoint;
    public HealthLevel healthLevel;
    public PowerUp powerLevel;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            player.transform.position = respawnPoint.transform.position;
            healthLevel.AddHealth(100f);
            powerLevel.SetToZero();

        }
            
    }
}
