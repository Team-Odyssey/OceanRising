using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MorphFins : MonoBehaviour
{
    [SerializeField] private List<GameObject> fins;
    [SerializeField] public SteamVR_Action_Boolean MorphFish;
    private int CurrentIndex;
    private bool HasMorphed;
    
    private void Awake()
    {
        CurrentIndex = 0;
        ShowFinForIndex(CurrentIndex);
    }

    private void ShowFinForIndex(int index)
    {
        for (int i = 0; i < fins.Count; i++)
        {
            var fin = fins[i];
            fin.SetActive(i == index);
        }
    }

    private void IncrementIndex()
    {
        CurrentIndex++;
        if (CurrentIndex == fins.Count)
        {
            CurrentIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool MorphFishState = MorphFish.state;
        if (MorphFishState)
        {
            if (!HasMorphed)
            {
                IncrementIndex();
                ShowFinForIndex(CurrentIndex);
                HasMorphed = true;   
            }
        }
        else
        {
            HasMorphed = false;
        }
    }
}
