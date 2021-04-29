using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    public Text code; //Passcode that will be shown in input field
    int codeNum; //Numbers in the Input field
    int intIndex = 0; //How many numbers
    int[] intChar = new int[3]; //Array of numbers
    public void numberFunction(int number)
    {
        intChar[intIndex] = number; //Stores int into int array
        number.ToString();
        codeNum = codeNum + number; //Displays next number
        code.text = codeNum.ToString(); //Displays in text field
        intIndex++;
    }

    public void backSpace()
    {

    }

}
