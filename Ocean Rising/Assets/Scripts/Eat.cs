using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "TestFood"))
        {
            HealthLevel.currentHealth += 10f;
            Debug.Log("HL+10");
            Destroy(other.gameObject);
        }
    }
}
