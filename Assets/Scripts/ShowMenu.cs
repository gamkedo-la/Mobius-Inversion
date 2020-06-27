using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    
    [SerializeField]
    private CanvasGroup framerateCanvas;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Show();
        }

        if (Input.GetKeyUp("r"))
        {
            Hide();
        }

    }


    void Show() {
    framerateCanvas.alpha = 1f;
    framerateCanvas.blocksRaycasts = true;
    framerateCanvas.interactable = true;
    }

    void Hide() {
    framerateCanvas.alpha = 0f;
    framerateCanvas.blocksRaycasts = false;
    framerateCanvas.interactable = false;
    }

}
