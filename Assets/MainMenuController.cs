using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{

    public void StartBtn()
    {
        InputField AgeInput = GameObject.FindWithTag("AgeField").GetComponent<InputField>();
        Text ageText = AgeInput.GetComponent<Text>();
        if (!string.IsNullOrEmpty(ageText.text))
        {
          

        }
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }

}
