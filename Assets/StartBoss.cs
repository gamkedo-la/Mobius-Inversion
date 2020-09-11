using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public StartBossFightAfterLevelEnd sBALE;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Bounds.instance.rightX || Input.GetKeyDown(KeyCode.F))
        {
            sBALE.WakeBoss();
            this.enabled = false;
        }
    }
}
