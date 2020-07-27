﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testClick : MonoBehaviour
{
    Ray ray;
    public float decaytime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                ShieldRaycast shieldRaycast = hit.collider.gameObject.GetComponent<ShieldRaycast>();
                if (shieldRaycast)
                {
                    decaytime = 3f;
                    shieldRaycast.SetHitPosition(hit.point, decaytime);
                }
               /*  print(hit.point);
                print(hit.collider.gameObject); */
            }
        }


    }
}
