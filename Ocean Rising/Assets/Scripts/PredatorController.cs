using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PredatorController : MonoBehaviour
{
    //Transform player;
    public GameObject player;
    public float sightRange = 30f;
    public float attackRange = 3f;


    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //predator = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        var destination = player.transform.position;
        var step = 1f * Time.deltaTime;

        if (Vector3.Distance(transform.position, destination) <= sightRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            //transform.LookAt(player.transform);
            //transform.rotation = Quaternion.LookRotation(transform.position, destination - transform.position);
            FaceTarget();
        }

        void FaceTarget()
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            //Vector3 direction = player.transform.position.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        }

        /*playerInsightRange = Physics.CheckSphere(transform.position, sightRange);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange);*/



    }

}
