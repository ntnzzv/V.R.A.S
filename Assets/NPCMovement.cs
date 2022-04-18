using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCMovement : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent npc;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
               
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
