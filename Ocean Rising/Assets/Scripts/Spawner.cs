using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] food;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    public int min = 3;
    public int max = 10;
    public int numFood = 0;

    int randFood;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            if (numFood < max)
            {
                randFood = Random.Range(0, 2); //Randomly choose 1 of 2 possible foods

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));


                Instantiate(food[randFood], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation); //Spawn object at given location

                numFood += 1;
                Debug.Log("numFood = " + numFood + " of max " + max);
            }

            yield return new WaitForSeconds(spawnWait);
        }
    }
}