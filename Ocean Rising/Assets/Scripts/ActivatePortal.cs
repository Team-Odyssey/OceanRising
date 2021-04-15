using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortal : MonoBehaviour
{
    public GameObject portal;
    public PowerUp power;

    void Start()
    {
        portal.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(power.isMax()){ 
            portal.SetActive(true);
        }
    }
}
