using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    public float lifeSpan;
    private float lifeStart;
    void Start()
    {
        lifeStart = Time.time;
    }

    void Update()
    {
        if(Time.time > (lifeSpan + lifeStart))
        {
            Destroy(this.gameObject);
        }
    }
}