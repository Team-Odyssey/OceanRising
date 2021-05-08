using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome : MonoBehaviour
{
    public float chromosome;

    // Start is called before the first frame update
    public void AddChromosome(float amt)
    {
        this.chromosome = this.chromosome + amt;
        Debug.Log("Adding " + amt + " chromosomes to the player.");
        Debug.Log("Chromosome count: " + this.chromosome);
    }
}
