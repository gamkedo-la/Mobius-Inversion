using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PanelAnimator : MonoBehaviour
{
    public RectTransform panelrect;
    public RectTransform panel2rect;
    public GameObject panel2;
    

    /* public void ShowLevelSelectPanel()
    {
        // StartCoroutine(PanelAnimation());
        SceneManager.LoadScene("MainScene");
    } */


    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            StartCoroutine(PanelAnimationOutBack());
            StartCoroutine(PanelAnimationInFront());
             }

    }

    private IEnumerator PanelAnimationOutBack()
    {
        //panelBG.SetActive(true);
        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            //this code will run for 1s exact
            panelrect.localScale = Vector3.one * Mathf.LerpUnclamped(0.5f, 0f, Easings.QuadraticEaseOut(timer));
            yield return null;
        }
    }

    private IEnumerator PanelAnimationInFront()
    {
         yield return new WaitForSeconds(0.5f);
        panel2.SetActive(true);
        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            //this code will run for 1s exact
            panel2rect.localScale = Vector3.one * Mathf.LerpUnclamped(2.0f, 0.5f, Easings.QuadraticEaseIn(timer));
               yield return null;
        }
    }

}
