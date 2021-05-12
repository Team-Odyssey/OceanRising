using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public HealthLevel healthLevel;
    public PowerUp powerLevel;
    public int count = 0;
    public Text score;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "TestFood"))
        {
            healthLevel.AddHealth(100f);
            powerLevel.AddPower(1f);
            count += 1;
<<<<<<< HEAD

            GameObject.Instantiate(bloodSplatter);
            //bloodSplatter.SetActive(true);
            Debug.Log("bloodSplater triggered by Eat.cs");
=======
>>>>>>> f650d47d154ed61fbbce2e04b10e037597f06b1a
            Destroy(other.gameObject);

            //bloodSplatter.SetActive(false);
        }
    }

    void Start()
    {
        score.text = "Fishes Eaten: ";
    }
    void Update()
    {
        score.text = "Fishes Eaten: " + count;
    }
}
