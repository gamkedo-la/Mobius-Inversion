using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour
{

    public ShipColor PassThrough;

    public Color RedS;
    public Color BlueS;
    public Color GreenS;
    public Color PurpleS;

    public float timer = 5.0f;
    public float reset = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        PassThrough = (ShipColor)Random.Range(0, 4);

        

        if(PassThrough == ShipColor.Green)
        {
            gameObject.GetComponent<Renderer>().material.color = GreenS;
        }
        if (PassThrough == ShipColor.Red)
        {
            gameObject.GetComponent<Renderer>().material.color = RedS;
        }
        if (PassThrough == ShipColor.Purple)
        {
            gameObject.GetComponent<Renderer>().material.color = PurpleS;
        }
        if (PassThrough == ShipColor.Yellow)
        {
            gameObject.GetComponent<Renderer>().material.color = BlueS;
        }


    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            PassThrough = (ShipColor)Random.Range(0, 4);



            if (PassThrough == ShipColor.Green)
            {
                gameObject.GetComponent<Renderer>().material.color = GreenS;
            }
            if (PassThrough == ShipColor.Red)
            {
                gameObject.GetComponent<Renderer>().material.color = RedS;
            }
            if (PassThrough == ShipColor.Purple)
            {
                gameObject.GetComponent<Renderer>().material.color = PurpleS;
            }
            if (PassThrough == ShipColor.Yellow)
            {
                gameObject.GetComponent<Renderer>().material.color = BlueS;
            }

            timer = reset;

        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerShot>().FiredFrom != PassThrough)
        {
            
            Destroy(collision.gameObject);
        }
    }

}
