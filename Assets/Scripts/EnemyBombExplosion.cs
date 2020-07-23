using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.0f);
        //transform.Rotate(0f, -90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
