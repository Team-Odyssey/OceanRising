﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
    public void GoRegister(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
