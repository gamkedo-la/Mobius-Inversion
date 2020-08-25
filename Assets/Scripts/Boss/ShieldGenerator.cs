using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour
{

    public GameObject shieldPrefab;

    public float Timer;
    public float Reset;

    public int stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Boss").GetComponent<BossStages>().Stage == stage)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                Generate();
                Timer = Reset;

            }
        }

    }


    public void Generate()
    {

        GameObject shield = (GameObject)Instantiate(shieldPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);

    }

}
