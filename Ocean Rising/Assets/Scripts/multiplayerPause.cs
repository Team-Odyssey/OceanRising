using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.EventSystems;

public class multiplayerPause : MonoBehaviour
{
    [SerializeField] public SteamVR_Action_Boolean moveUp;
    [SerializeField] public SteamVR_Action_Boolean moveDown;
    [SerializeField] public SteamVR_Action_Boolean menuButton;
    public Canvas multiPause;
    public bool state = false;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool menuButtonPressed = menuButton.state;
        if (time > 0f){
        // Subtract the difference of the last time the method has been called
            time -= Time.deltaTime;
        }
        if(menuButtonPressed && time <= 0)
        {
            state = !state;   
            popMenu(state);
            time = .5f;
        }
    }
    void popMenu(bool state){
        multiPause.enabled = state;
    }
}
