
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class FinalStageController : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public Text uid;
    // Start is called before the first frame update
    void Start()
    {
        var r = new System.Random();
        int n = r.Next(10000);
        uid.text = n.ToString();
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