using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCMovement2 : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent npc;
    private Animator animator;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("OVRCameraRig");
        Vector3 bar = cam.transform.position;
        transform.position = bar;
        transform.Translate( 0 ,0 ,-1.1f);
        npc = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        npc.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        npc.updateRotation = false;

        if (npc.remainingDistance <= npc.stoppingDistance || npc.isStopped)
        {
            animator.ResetTrigger("walk");
            animator.SetTrigger("idle");
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }
}
