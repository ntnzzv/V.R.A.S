using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public TMP_InputField AgeInputField;

    public void StartBtn()
    {
       
        Debug.Log("Lets see whats up :" + AgeInputField.text);
        if (!string.IsNullOrEmpty(AgeInputField.text))
        {
          
                 SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
        //SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }

}
