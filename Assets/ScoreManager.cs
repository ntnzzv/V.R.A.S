using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int globalRedScore = 0;
    public static int globalBlueScore = 0;
    public static int globalOrangeScore = 0;
    public FadeScreen fadeScreen;
    // Start is called before the first frame update
    [SerializeField] public GameObject c1;
    [SerializeField] public GameObject c2;

    [SerializeField] AudioClip confettiSound; 

    [SerializeField] AudioClip appluadSound; 
     [SerializeField] AudioSource audioSource;
     [SerializeField] ParticleSystem confettiSystem;
     [SerializeField] Animator animator;
    
    void Start()
    {
        globalRedScore = 0;
        globalBlueScore = 0 ;
        globalOrangeScore = 0 ;
         DisableCanvas(c2);
        //EnableCanvas(c1);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        if( globalRedScore == 3 && globalBlueScore == 3 && globalOrangeScore == 3 )
            {
                Debug.Log("EVERY ONE IS IN PLACE");
                if(c2.activeSelf == false)
                {
                    DisableCanvas(c1);
                    EnableCanvas(c2);
                    confettiSystem.Play();
                    audioSource.PlayOneShot(confettiSound);
                    audioSource.PlayOneShot(appluadSound);

                   
                    Invoke("ChangeTheScene", 10.0f);
        
                }
            }


    }


    void DisableCanvas(GameObject t) {
      t.SetActive(false);
    }

    void EnableCanvas(GameObject t) {
      t.SetActive(true);
    }

    void ChangeTheScene(){
        //Enter correct scene name 
        MainManager.Instance.GoToNextScene(fadeScreen);
    }
}
