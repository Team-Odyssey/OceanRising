using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeInput : MonoBehaviour
{
    public Text name;
    string word;
    int wordIndex = 0;
    string alpha;

    public void alphabetFunction(string alphabet)
    {
        wordIndex++;
        word = word + alphabet;
        name.text = word;
    }

}
