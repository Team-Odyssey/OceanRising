using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [Header("GUI")]
    public Slider healthSlider;

    [Header("Health")]
    [Min(0)]
    public float maxPower;
    public float currentPower;
    public float powerDrain = 0.1f;

    void Start()
    {
        currentPower = 0;
        healthSlider.maxValue = maxPower;
    }

    void Update()
    {
        if(currentPower == maxPower){
            powerDrain = 0;
        }
        currentPower = Mathf.Clamp(currentPower - (Time.deltaTime * powerDrain), 0, maxPower);
    }

    void OnGUI()
    {
        healthSlider.value = currentPower;
    }

    public void AddPower(float amt)
    {
        this.currentPower = this.currentPower + amt;
        Debug.Log("Adding " + amt + " power to the player.");
        Debug.Log("Current power: " + this.currentPower);
    }

    public void SetToZero(){
        this.currentPower = 0f;
    }

    public bool isMax(){
        if(currentPower == maxPower){
            return true;
        }else{
            return false;
        }
    }
}
