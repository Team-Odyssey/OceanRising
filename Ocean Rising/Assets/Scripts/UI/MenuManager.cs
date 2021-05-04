using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Panel currentPanel;
    private List<Panel> panelHistory = new List<Panel>();

    private void Start(){
        SetupPanels();
    }

    private void SetupPanels(){
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach(Panel panel in panels)
            panel.Setup(this);
        currentPanel.Show();
    }


    public void GoToPrevious(){
        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrentWithHistory(Panel newPanel){
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);
        newPanel.Show();
    }

    public void SetCurrent(Panel newPanel){
        currentPanel.Hide();
        currentPanel = newPanel;
        currentPanel.Show();
    }
    public void doExitGame() {
     Application.Quit();
    }
    
    public void sceneTransition(string newScene){ 
        SceneManager.LoadScene(newScene);
    }
}
