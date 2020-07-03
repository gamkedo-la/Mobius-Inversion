﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4.0f);
        //transform.Rotate(0f, -90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * 20.0f * -gameObject.transform.right;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);

            Debug.Log("Bullets Mutually Annillated, TO DO: ADD EXPLOSION VFX");
        }
    }
}
