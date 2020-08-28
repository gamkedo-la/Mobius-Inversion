using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{ 
    public ShipColor FiredFrom;
    public float bulletSpeed = 10.0f;
    public float bulletTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletTime);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * bulletSpeed * Vector3.right;
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
