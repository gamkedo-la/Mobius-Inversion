using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PanelAnimator : MonoBehaviour
{
    public RectTransform panelrect;
    public RectTransform panel2rect;
    public RectTransform panel3rect;

    public RectTransform panel4rect;

    public RectTransform panel5rect;
    public GameObject panel2;
     public GameObject panel3;
    public GameObject panel4;

     public GameObject panel5;
      public GameObject panel;

      private bool shipinfo=false;

    /* public void ShowLevelSelectPanel()
    {
        // StartCoroutine(PanelAnimation());
        SceneManager.LoadScene("MainScene");
    } */


    void Update()
    {
        if (shipinfo == true)
        {
            if(Input.anyKey)
            {
            Debug.Log("any key pressed");
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
            panel5.SetActive(false);
            //StartCoroutine(PanelAnimationInFront(panelrect, panel));
            shipinfo = !shipinfo;
            }
        } 
        else {        
        
        if (Input.GetKeyDown("1"))
        {
            shipinfo = !shipinfo;
            StartCoroutine(PanelAnimationOutBack(panelrect));
            StartCoroutine(PanelAnimationInFront(panel2rect, panel2));
             }

        if (Input.GetKeyDown("2"))
        {
            shipinfo = !shipinfo;
            StartCoroutine(PanelAnimationOutBack(panelrect));
            StartCoroutine(PanelAnimationInFront(panel3rect, panel3));
             }
        
        if (Input.GetKeyDown("3"))
        {
            shipinfo = !shipinfo;
            StartCoroutine(PanelAnimationOutBack(panelrect));
            StartCoroutine(PanelAnimationInFront(panel4rect, panel4));
             }

         if (Input.GetKeyDown("4"))
        {
            shipinfo = !shipinfo;
            StartCoroutine(PanelAnimationOutBack(panelrect));
            StartCoroutine(PanelAnimationInFront(panel5rect, panel5));
             }
        }

    }

    private IEnumerator PanelAnimationOutBack(RectTransform panel)
    {
        //panelBG.SetActive(true);
        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            //this code will run for 1s exact
            panel.localScale = Vector3.one * Mathf.LerpUnclamped(0.5f, 0f, Easings.QuadraticEaseOut(timer));
            yield return null;
        }
    }

    private IEnumerator PanelAnimationInFront(RectTransform panel, GameObject panelobject)
    {
         yield return new WaitForSeconds(0.5f);
        panelobject.SetActive(true);
        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            //this code will run for 1s exact
            panel.localScale = Vector3.one * Mathf.LerpUnclamped(2.0f, 0.5f, Easings.QuadraticEaseIn(timer));
               yield return null;
        }
    }

}
