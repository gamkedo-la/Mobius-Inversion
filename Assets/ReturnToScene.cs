using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToScene : MonoBehaviour
{
   
   public void unloadOptions ()
        {
            SceneManager.UnloadSceneAsync("OptionsScene_Andy");

        }
    
}
