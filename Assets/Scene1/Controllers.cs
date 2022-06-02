using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controllers : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent woman;
    public GameObject changingText;
    public string text1;
    public string text2;
    private Text text;
    public FadeScreen fadeScreen;


    // Start is called before the first frame update
    void Start()
    {
        if (!woman.hasPath)
        {
            woman.SetDestination(player.position);
            woman.isStopped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //--- Right Controller
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Text text = changingText.GetComponent<Text>();    
            woman.isStopped = !woman.isStopped;
            Debug.Log(woman.remainingDistance);
            text.text = text1;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) 
           && (woman.remainingDistance <= woman.stoppingDistance || woman.isStopped))
        {   
            Text text = changingText.GetComponent<Text>();
            MainManager.Instance.GoToScene(fadeScreen ,SceneManager.GetActiveScene().buildIndex);
            text.text = text2;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch) && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            if (woman.isStopped)
            {
                switch (SceneManager.GetActiveScene().name)
                {
                    case "towardsPlayer":
                        MainManager.Instance.DistanceBefore = woman.remainingDistance;
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                    case "GrabGame":
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                    case "fromPlayer":
                        MainManager.Instance.DistanceAfter = woman.remainingDistance;
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                }
            }
        }
    }

    //public void TextChange(Text msg)
    //{
     //   changingText.GetComponent<Text>().set=msg;
   // }
}