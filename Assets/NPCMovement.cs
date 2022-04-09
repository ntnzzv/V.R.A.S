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
        npc.SetDestination(player.position);
        
        animator.SetTrigger("walk");
        if (npc.remainingDistance <= npc.stoppingDistance)
        {
            animator.ResetTrigger("walk");
            animator.SetTrigger("idle");
        }
        Debug.Log(npc.remainingDistance);
    }
}
