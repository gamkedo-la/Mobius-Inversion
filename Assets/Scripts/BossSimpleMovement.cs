﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleMovement : MonoBehaviour
{

    public int upperBound;
    public int lowerBound;

    public float step;

    Vector3 positionTemp = new Vector3(0,0,0);


    // Start is called before the first frame update
    void Start()
    {
        positionTemp = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<BossStages>().Stage == 1)
        {

            positionTemp.y += step;

            gameObject.transform.position = positionTemp;

            if (positionTemp.y > upperBound || positionTemp.y < lowerBound)
            {
                step *= -1;

            }

        }
    }
}
