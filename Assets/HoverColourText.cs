using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class HoverColourText : MonoBehaviour
{
    
    [SerializeField] private GameObject textcolour;
    public void onHover()
    {
        TextMeshProUGUI textmeshPro = textcolour.GetComponent<TextMeshProUGUI>();
        textmeshPro.color = new Color32(255, 214, 53, 255);
       //Debug.Log("hover");
    }

    public void onExit()
    {
        TextMeshProUGUI textmeshPro = textcolour.GetComponent<TextMeshProUGUI>();
        textmeshPro.color = new Color32(255, 91, 24, 255);
       //Debug.Log("hover");
    }
}
