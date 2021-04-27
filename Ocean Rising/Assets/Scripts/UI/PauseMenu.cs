using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        Debug.Log("Key has been pressed");
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Debug.Log("Game has resumed");
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
        Debug.Log("Game is Paused");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu has been loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
