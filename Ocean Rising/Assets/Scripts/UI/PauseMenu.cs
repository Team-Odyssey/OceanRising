using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public SteamVR_Action_Boolean menuButton;
    public static bool isGamePaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        bool menuButtonPressed = menuButton.state;
        if(menuButtonPressed)
        {
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu has been loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
