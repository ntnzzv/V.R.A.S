using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeboard : MonoBehaviour
{
    private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";
    public void InputBtn()
    {
       overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
       if (overlayKeyboard != null)
       inputText = overlayKeyboard.text; 

    }
}
