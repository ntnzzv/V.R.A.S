using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
public void StartBtn()
{
         SceneManager.LoadScene("main", LoadSceneMode.Single);
   // SceneManager.LoadScene("main");
}


}
