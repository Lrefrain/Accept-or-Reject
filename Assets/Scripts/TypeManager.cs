using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeManager : MonoBehaviour
{
    public Text textField;
    // Start is called before the first frame update

    public void TypeA()
    {
        textField.text += "A";
    }
    public void TypeB()
    {
        textField.text += "B";
    }
    public void TypeC()
    {
        textField.text += "C";
    }
    public void TypeD()
    {
        textField.text += "D";
    }
    public void TypeE()
    {
        textField.text += "E";
    }
    public void TypeF()
    {
        textField.text += "F";
    }
    public void TypeG()
    {
        textField.text += "G";
    }
    public void TypeH()
    {
        textField.text += "H";
    }
    public void TypeI()
    {
        textField.text += "I";
    }
    public void TypeJ()
    {
        textField.text += "J";
    }

    public void TypeK()
    {
        textField.text += "K";
    }
    public void TypeL()
    {
        textField.text += "L";
    }
    public void TypeM()
    {
        textField.text += "M";
    }
    public void TypeN()
    {
        textField.text += "N";
    }
    public void TypeO()
    {
        textField.text += "O";
    }
    public void TypeP()
    {
        textField.text += "P";
    }
    public void TypeQ()
    {
        textField.text += "Q";
    }
    public void TypeR()
    {
        textField.text += "R";
    }
    public void TypeS()
    {
        textField.text += "S";
    }
    public void TypeT()
    {
        textField.text += "T";
    }
    public void TypeU()
    {
        textField.text += "U";
    }
    public void TypeV()
    {
        textField.text += "V";
    }
    public void TypeW()
    {
        textField.text += "W";
    }
    public void TypeX()
    {
        textField.text += "X";
    }
    public void TypeY()
    {
        textField.text += "Y";
    }
    public void TypeZ()
    {
        textField.text += "Z";
    }
    public void BackSpace()
    {
        string originalString = textField.text;
        textField.text = originalString.Substring(0, originalString.Length - 1);
    }
}
