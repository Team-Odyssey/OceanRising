using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeInput : MonoBehaviour
{
    public Text name; //Username that will be shown in input field
    string word; //Characters in the Input field
    int charIndex = 0; //How many letters
    char[] nameChar = new char[15]; //Array of letters
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
        string str = new string(nameChar);
        word = str;
        word.ToCharArray();
        word.Remove(charIndex);
        string newword = word.ToString();
        name.text = newword;
        charIndex--;
    }

}
