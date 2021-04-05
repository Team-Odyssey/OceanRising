using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLevel : MonoBehaviour
{
    [Header("GUI")]
    public Slider healthSlider;

    [Header("Health")]
    [Min(0)]
    public float maxHealth;
    public float currentHealth;
    public float healthDrain = 0.1f;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth - (Time.deltaTime * healthDrain), 0, maxHealth);
    }

    void OnGUI()
    {
        healthSlider.value = currentHealth;
    }

    public void AddHealth(float amt)
    {
        this.currentHealth = this.currentHealth + amt;
        Debug.Log("Adding " + amt + " health to the player.");
        Debug.Log("Current health: " + this.currentHealth);
    }
}
