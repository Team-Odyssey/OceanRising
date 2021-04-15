using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string NewLevel= "Environment";
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(NewLevel);
    }
}