using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    private bool gameHasEnded = false;

    public float restartDelay = 2f;

    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Invoke("Restart", restartDelay);

    }

    // public void EndGame()
    // {
    //     if (gameHasEnded == false)
    //     {
    //         gameHasEnded = true;
    //         Debug.Log("GAME OVER");
    //         Invoke("Restart", restartDelay);
    //     }
    // }
    
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
