using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4.0f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * 20.0f * gameObject.transform.forward;
       
    }
}
