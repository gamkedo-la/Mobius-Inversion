using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{ 
    public ShipColor FiredFrom;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.5f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * 20.0f * Vector3.right;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Right Edge 2D")
        {
            //Debug.Log("Touched 2D");
            Destroy(gameObject);
        }
    }
}
