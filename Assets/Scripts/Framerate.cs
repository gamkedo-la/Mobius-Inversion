using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Framerate : MonoBehaviour
{
    //Toggle Toggle60;
    private  bool FramerateHigh;
   
    void Start()
    {
        
        // This script now needs to define frame rate from playerprefs value once set up, also should this then be awake?

        /* Toggle60 = GetComponent<Toggle>();
        Toggle60.onValueChanged.AddListener(delegate {
            ToggleValueChanged(Toggle60);
        }); */

        //Set initial frame rate to 60, vsync turned off - Note I could not get Unity to respect the project level vsync settings for some reason
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        FramerateHigh = true;             
    }

    /* public void ToggleValueChanged (bool toggle )
    {
        if (FramerateHigh == true)
            {Application.targetFrameRate = 30;
            }

        else 
            {
            Application.targetFrameRate = 60;
            }
        
        FramerateHigh = !FramerateHigh;
    } */


    
}
