using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeInput : MonoBehaviour
{
    public TMP_Text name; //Username that will be shown in input field
    public TMP_InputField store;
    string word; //Characters in the Input field
    int charIndex = 0; //How many letters
    char[] nameChar = new char[20]; //Array of letters
    string alpha;

    public void alphabetFunction(string alphabet)
    {
        charIndex++;
        char[] keepchar = alphabet.ToCharArray(); //Turns alphabet into char
        nameChar[charIndex] = keepchar[0]; //Stores alphabet into char array
        word = word + alphabet; //Displays next letter
        name.text = word; //Displays in text field
    }

    public void backSpace()
    {
        nameChar[charIndex] = ' ';
        word = word.Remove(word.Length - 1, 1);
        name.text = word;
        charIndex--;
    }

}
