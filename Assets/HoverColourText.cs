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
    [SerializeField] private AudioClip   UIclick;
    [SerializeField] private GameObject  marker;
    public void onHover()
    {
        TextMeshProUGUI textmeshPro = textcolour.GetComponent<TextMeshProUGUI>();
        textmeshPro.color = new Color32(255, 214, 53, 255);
        UIaudiosource.PlayOneShot(UIbeep, 0.5f);
        marker.SetActive(true);
    }

    public void onExit()
    {
        TextMeshProUGUI textmeshPro = textcolour.GetComponent<TextMeshProUGUI>();
        textmeshPro.color = new Color32(255, 91, 24, 255);
         marker.SetActive(false);
    }

  

    public void gotoMainScene()
        {
            UIaudiosource.PlayOneShot(UIclick, 0.5f);
            SceneManager.LoadSceneAsync("MainScene");
        }
    
    public void gotoTutorialScene()
        {
            UIaudiosource.PlayOneShot(UIclick, 0.5f);
            SceneManager.LoadSceneAsync("TutorialScene_Andy");
        }
    
    public void gotoOptionsScene()
        {
            UIaudiosource.PlayOneShot(UIclick, 0.5f);
            SceneManager.LoadSceneAsync("OptionsScene_Andy", LoadSceneMode.Additive);
        }
    

}
