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

    public GameObject bloodSplatter;
    //private ParticleSystem ps;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "TestFood"))
        {

            //ps.Play();
            bloodSplatter.SetActive(true);
            StartCoroutine (StopBlood());

            healthLevel.AddHealth(100f);
            powerLevel.AddPower(1f);
            count += 1;
            Destroy(other.gameObject);

          
            //ps.Stop();
            
        }
        if (other.gameObject.tag.Equals("Predator")){ 
            count = 0;
        }
    }

    void Start()
    {
        //ps = GetGameObject<ParticleSystem>();
        bloodSplatter.SetActive(false);
        score.text = "Fishes Eaten: ";
    }
    void Update()
    {
        score.text = "Fishes Eaten: " + count;
    }
    
    IEnumerator StopBlood(){
        yield return new WaitForSeconds(1);
        bloodSplatter.SetActive(false);
    }
}
