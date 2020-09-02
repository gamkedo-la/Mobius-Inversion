using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimator : MonoBehaviour
{
    public RectTransform panel;
    public GameObject panelBG;

    public void ShowLevelSelectPanel()
    {
        StartCoroutine(PanelAnimation());
    }

    private IEnumerator PanelAnimation()
    {
        panelBG.SetActive(true);
        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            //this code will run for 1s exact
            panel.localScale = Vector3.one * Mathf.LerpUnclamped(0f, 1f, Easings.ElasticEaseOut(timer));
            yield return null;
        }
    }

}
