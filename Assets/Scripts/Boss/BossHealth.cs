using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int HitPoints = 100;

    public int Stage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {



        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {


            if (GameObject.Find("Boss").GetComponent<BossStages>().Stage == Stage)
            {
                HitPoints -= 10;
            }
            Destroy(other.gameObject);

            if(HitPoints <= 0)
            {

                Destroy(gameObject);

            }

        }

    }

}
