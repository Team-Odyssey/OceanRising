using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLevel : MonoBehaviour
{
    public Slider healthSlider;

    public float MaxHealth;
    public static float currentHealth;

    private bool stopTimer;
    void Start()
    {
        stopTimer = false;
        healthSlider.maxValue = MaxHealth;
    }

    void Update()
    {
        currentHealth = MaxHealth - Time.time;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            healthSlider.value = currentHealth;
        }
    }
}
