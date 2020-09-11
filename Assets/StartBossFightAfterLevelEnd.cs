using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFightAfterLevelEnd : MonoBehaviour
{
    public GameObject bossToWake;
    public ScrollWorld scrollToStop;

    // Update is called once per frame
    public void WakeBoss()
    {
        if(bossToWake != null && bossToWake.activeSelf == false)
        {
            bossToWake.SetActive(true);
            scrollToStop.enabled = false;

            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
