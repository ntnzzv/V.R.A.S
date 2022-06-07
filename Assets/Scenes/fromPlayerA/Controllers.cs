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
    private int nextSceneCounter = 0;
    public Transform headsetFromStage;

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
            text.text = text1;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) 
           && (woman.remainingDistance <= woman.stoppingDistance || woman.isStopped))
        {   
            Text text = changingText.GetComponent<Text>();
            MainManager.Instance.GoToScene(fadeScreen ,SceneManager.GetActiveScene().buildIndex);
            text.text = text2;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            nextSceneCounter++;
            if (woman.isStopped && nextSceneCounter == 3)
            {
                nextSceneCounter = 0;
                switch (SceneManager.GetActiveScene().name)
                {
                    case "towardsPlayerA":
                        MainManager.Instance.DistanceTowardsA = woman.remainingDistance/2;
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                    case "towardsPlayerB":
                        MainManager.Instance.DistanceTowardsB = woman.remainingDistance/2;
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                    case "fromPlayerA":
                        MainManager.Instance.DistanceFromA = Vector3.Distance(woman.nextPosition, headsetFromStage.position)/2;
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                    case "fromPlayerB":
                        MainManager.Instance.DistanceFromB = Vector3.Distance(woman.nextPosition, headsetFromStage.position)/2;
                        MainManager.Instance.GoToNextScene(fadeScreen);
                        break;
                }
            }
        }
    }
}