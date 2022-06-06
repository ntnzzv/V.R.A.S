using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public TMP_InputField AgeInputField;
    public FadeScreen fadeScreen;
    public TMP_InputField AQInputField;
    public Text missingDataText;
    public void StartBtn()
    {
        if ((!string.IsNullOrEmpty(AgeInputField.text) && !string.IsNullOrEmpty(AQInputField.text)) && 
            (int.Parse(AgeInputField.text) < 99 && int.Parse(AgeInputField.text) > 0)
            && (int.Parse(AQInputField.text) <= 50 && int.Parse(AQInputField.text) > 0))
        {
            MainManager.Instance.AqTest = AQInputField.text;
            MainManager.Instance.PlayerAge = AgeInputField.text;
            MainManager.Instance.GoToNextScene(fadeScreen);
        }
        else
        {
            Color missingData = missingDataText.color;
            missingData.a = 255;
            missingDataText.color = missingData;
        }
    }
    public void LoadMainMenu()
    {
        MainManager.Instance.GoToScene(fadeScreen, 0);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }

}