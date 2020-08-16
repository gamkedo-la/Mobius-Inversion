using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class HoverColourText : MonoBehaviour
{
    
    [SerializeField] private GameObject textcolour;
    [SerializeField] private AudioSource UIaudiosource;
    [SerializeField] private AudioClip   UIbeep;
    public void onHover()
    {
        TextMeshProUGUI textmeshPro = textcolour.GetComponent<TextMeshProUGUI>();
        textmeshPro.color = new Color32(255, 214, 53, 255);
        UIaudiosource.PlayOneShot(UIbeep, 0.5f);
    }

    public void onExit()
    {
        TextMeshProUGUI textmeshPro = textcolour.GetComponent<TextMeshProUGUI>();
        textmeshPro.color = new Color32(255, 91, 24, 255);
       
    }

    public void gotoMainScene()
        {
            SceneManager.LoadScene("MainScene");
        }
    
    public void gotoTutorialScene()
        {
            SceneManager.LoadScene("TutorialScene_Andy");
        }
    
    public void gotoOptionsScene()
        {
            SceneManager.LoadScene("OptionsScene_Andy");
        }

}
