using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManage gameManage;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        gameManage.CompleteLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
