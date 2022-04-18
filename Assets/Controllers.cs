using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Controllers : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent woman;
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
            
            woman.isStopped = !woman.isStopped;
            Debug.Log(woman.remainingDistance);
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) 
           && (woman.remainingDistance <= woman.stoppingDistance || woman.isStopped))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}