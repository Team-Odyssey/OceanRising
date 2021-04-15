using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    Transform predator;
    public float sightRange = 10f;


    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        predator = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        var approach = predator.transform.position;
        var step = 1f * Time.deltaTime;

        if (Vector3.Distance(transform.position, approach) <= sightRange)
        {
            transform.position = -(Vector3.MoveTowards(transform.position, approach, step));
            Quaternion targetRotation = Quaternion.LookRotation(-predator.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);

        }
    }
}
