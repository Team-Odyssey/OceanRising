using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public HealthLevel healthLevel;
    public PowerUp powerLevel;
    public int count = 0;
    public GameObject bloodSplatter;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "TestFood"))
        {
            healthLevel.AddHealth(100f);
            powerLevel.AddPower(1f);

            count += 1;

            GameObject.Instantiate(bloodSplatter);
            //bloodSplatter.SetActive(true);
            Debug.Log("bloodSplater triggered by Eat.cs");
            Destroy(other.gameObject);

            //bloodSplatter.SetActive(false);
        }
    }
}
