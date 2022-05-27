using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controllers2 : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent woman;
    public GameObject changingText;
    public string text1;
    public string text2;
    private Text text;


    // Start is called before the first frame update
    void Start()
    {
        if (!woman.hasPath)
        {
            woman.updateRotation = false;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            text.text = text2;
        }

    }

    //public void TextChange(Text msg)
    //{
     //   changingText.GetComponent<Text>().set=msg;
   // }
}