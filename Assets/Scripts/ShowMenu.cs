using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowMenu : MonoBehaviour
{
    
   /*  [SerializeField]
    private CanvasGroup framerateCanvas; */

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            // Need to set up so only calls seen once, set boolean, reset when exit options? How control as used from two scenes though?
            //Need to add game pause but have exception for game audio
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("OptionsScene_Andy", LoadSceneMode.Additive);
        }

        /* if (Input.GetKeyUp("r"))
        {
            Hide();
        } */

    }


    /* void Show() {
    framerateCanvas.alpha = 1f;
    framerateCanvas.blocksRaycasts = true;
    framerateCanvas.interactable = true;
    }

    void Hide() {
    framerateCanvas.alpha = 0f;
    framerateCanvas.blocksRaycasts = false;
    framerateCanvas.interactable = false;
    } */

}
