
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using System.Text;
public class FinalStageController : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public Text uid;

    // Start is called before the first frame update
    void Start()
    {
  
        Data simData = new Data();
        var date = DateTime.Now;

        simData.AQ = MainManager.Instance.AqTest;
        simData.age = MainManager.Instance.PlayerAge;
        simData.ipsAfrom = (MainManager.Instance.DistanceFromA * 100).ToString();
        simData.ipsAtowards = (MainManager.Instance.DistanceTowardsA * 100).ToString();
        simData.ipsBfrom = (MainManager.Instance.DistanceFromB * 100).ToString();
        simData.ipsBtowards = (MainManager.Instance.DistanceTowardsB * 100).ToString();
        simData.date = date.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("he-IL"));
        string json = JsonUtility.ToJson(simData);
        StartCoroutine(Post("https://vras.vercel.app/api/simulationsData", json, uid, (response) =>
        {
            if (response == null)
            {
                return;
            }
            // success
            Debug.Log(response);
        }));
    }
    public void LoadMainMenu()
    {
        MainManager.Instance.GoToScene(fadeScreen, 0);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
    public static IEnumerator Post(string uri, string data, Text textbox,Action<string> response)
    {
        using var postRequest = new UnityWebRequest();
        postRequest.url = uri; // PostUri is a string containing the url
        postRequest.method = "POST";
        postRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data)); // postData is Json file as a string
        postRequest.downloadHandler = new DownloadHandlerBuffer();
        postRequest.SetRequestHeader("Content-Type", "application/json");
        postRequest.SetRequestHeader("Authorization","er9qGuNDv8hjtr6U");
        yield return postRequest.SendWebRequest();

        if (postRequest.isNetworkError)
        {
            textbox.text = postRequest.error;
            response(null);
        }
        else
        {
            textbox.text = postRequest.downloadHandler.text;
            response(postRequest.downloadHandler.text);
        }
    }
}

[Serializable]
public class Data
{
    public string AQ;
    public string age;
    public string ipsAfrom;
    public string ipsAtowards;
    public string ipsBfrom;
    public string ipsBtowards;
    public string date;
}