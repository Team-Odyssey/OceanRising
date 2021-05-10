using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Transform respawnPoint;
    private HealthLevel healthLevel;
    private PowerUp powerLevel;

    void OnTriggerEnter(Collider other){
        
        if(other.tag == "Player"){
            healthLevel = other.GetComponent<HealthLevel>();
            powerLevel = other.GetComponent<PowerUp>();
            other.transform.position = respawnPoint.transform.position;
            healthLevel.AddHealth(100f);
            powerLevel.SetToZero();

        }
            
    }
}
