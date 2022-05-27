using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObjectOrange : MonoBehaviour
{
    [SerializeField] AudioClip confettiSound;
    [SerializeField] AudioClip girSuccessSound; 

    [SerializeField] AudioClip girWrongSound; 

    [SerializeField] AudioClip errorWrongSound; 
     AudioSource audioSource;
     [SerializeField] ParticleSystem confettiSystem;
    
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
                Debug.Log("Correct hit");
                confettiSystem.Play();
                audioSource.PlayOneShot(confettiSound);
                audioSource.PlayOneShot(girSuccessSound);
                ScoreManager.globalOrangeScore++;

                break;
            case "BluePlane":
                 Debug.Log("InCorrect hit");
                 audioSource.PlayOneShot(errorWrongSound);
                audioSource.PlayOneShot(girWrongSound);
                break;
            default: 
                break;   
                


        }
    }
}
