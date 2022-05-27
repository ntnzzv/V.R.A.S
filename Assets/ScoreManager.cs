using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int globalRedScore = 0;
    public static int globalBlueScore = 0;
    public static int globalOrangeScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        globalRedScore = 0;
        globalBlueScore = 0 ;
        globalOrangeScore = 0 ;
    }

    // Update is called once per frame
    void Update()
    {
        if( globalRedScore == 3 && globalBlueScore == 3 && globalOrangeScore == 3 )
            {
                Debug.Log("EVERY ONE IS IN PLACE");
            }
    }
}
