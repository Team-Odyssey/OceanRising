using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Passcode : MonoBehaviour
{
    public TMP_Text code; //Passcode that will be shown in input field
    public TMP_InputField storecode;
    string codeNum; //Numbers in the Input field
    int intIndex = 0; //How many numbers
    int[] intChar = new int[6]; //Array of numbers
    public void numberFunction(int number)
    {
        intChar[intIndex] = number; //Stores int into int array
        number.ToString();
        codeNum = codeNum + number.ToString(); //Displays next number
        code.text = codeNum.ToString(); //Displays in text field
        intIndex++;
    }

    public void backSpace()
    {   
        intChar[intIndex] = ' ';
        codeNum = codeNum.Remove(codeNum.Length - 1, 1);
        code.text = codeNum.ToString();
        intIndex--;

    }

}
