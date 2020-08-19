using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileLauncher : MonoBehaviour
{ 
    public GameObject missilePrefab;
    public float Timer;
    public float Reset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss").GetComponent<BossStages>().Stage == 1)
        {
            Timer -= Time.fixedDeltaTime;

            if (Timer <= 0)
            {
                Launch();
                Timer = Reset;

            }
        }

    }

    

    public void Launch()
    {

        GameObject missile = (GameObject)Instantiate(missilePrefab, gameObject.transform.position, Quaternion.identity);

    }

}
