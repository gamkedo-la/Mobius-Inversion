using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{

    private Vector3 pos1 = new Vector3(18, -15, 20);
    private Vector3 pos2 = new Vector3(18, 15, 20);
    public float speed = 1.0f;

    void Update()
    {
        if(transform.position.x > Bounds.instance.rightX)
        {
            return; //off the right side of the screen            
        }

        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}

