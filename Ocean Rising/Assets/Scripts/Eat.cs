using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public HealthLevel healthLevel;
    public int count = 0;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "TestFood"))
        {
            //healthLevel.Update();
            healthLevel.currentHealth += 10f;
            //healthLevel.healthSlider.value = 60f;
            count += 1;
            Debug.Log(count);
            Destroy(other.gameObject);
        }
    }
}
