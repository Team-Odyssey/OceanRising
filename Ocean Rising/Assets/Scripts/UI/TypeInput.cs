using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeInput : MonoBehaviour
{
    public Text name;
    string word;
    int wordIndex = 0;
    char[] nameChar = new char[30];
    string alpha;
    string alpha2;

    public void alphabetFunction(string alphabet)
    {
        wordIndex++;
        char[] keepchar = alphabet.ToCharArray();
        nameChar[wordIndex] = keepchar[0];
        alpha = nameChar[wordIndex].ToString();
        word = word + alpha;
        name.text = word;
    }

    public void backSpace()
    {
        if (wordIndex >=0)
        {
            wordIndex--;
            alpha2 = null;
            for(int i = 0; i < wordIndex; i++){
                alpha2 = alpha2 + nameChar[i].ToString();
            }
            word = alpha2;
            name.text = word;
        }
    }

}
