using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturntoStart : MonoBehaviour
{
    [SerializeField] private AudioSource UIaudiosource;
    [SerializeField] private AudioClip   UIclick;

   public void gotoTutorialScene()
        {
            UIaudiosource.PlayOneShot(UIclick, 0.5f);
            SceneManager.LoadSceneAsync("TutorialScene_Andy");
        }
}
