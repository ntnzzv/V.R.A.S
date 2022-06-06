using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObjectBlue : MonoBehaviour
{
    [SerializeField] AudioClip confettiSound;
    [SerializeField] AudioClip girSuccessSound; 

    [SerializeField] AudioClip girWrongSound; 

    [SerializeField] AudioClip errorWrongSound; 
    
    private Vector3 _initialScale;
    private Vector3 _initiallPosition;
     AudioSource audioSource;
     [SerializeField] ParticleSystem confettiSystem;

     [SerializeField] Animator animator;

    
     void Start() {
         audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
    
        switch(other.gameObject.tag)
        {
            case "RedPlane":
                Debug.Log("InCorrect hit");
                audioSource.PlayOneShot(errorWrongSound);
                audioSource.PlayOneShot(girWrongSound);
                break;
            case "OrangePlane":
                Debug.Log("InCorrect hit");
                audioSource.PlayOneShot(errorWrongSound);
                audioSource.PlayOneShot(girWrongSound);
                break;
            case "BluePlane":
                if (ScoreManager.globalBlueScore == 2)
                {
                    audioSource.PlayOneShot(confettiSound);
                    confettiSystem.Play();
                    audioSource.PlayOneShot(girSuccessSound);
                    animator.SetTrigger("goodjob");
                }
                ScoreManager.globalBlueScore++;
                other.gameObject.active = false;
                
                break;
            default: 
                break;   
                


        }
    }
}
