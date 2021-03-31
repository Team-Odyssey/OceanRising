using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public HealthLevel healthLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "TestFood"))
        {
            healthLevel.currentHealth += 10f;
            Debug.Log("HL+10");
            Destroy(other.gameObject);
        }
    }
}
