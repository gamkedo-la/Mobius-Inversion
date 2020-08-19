using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntrance : MonoBehaviour
{
    public int Estage = 1;

    Vector3 endPos = new Vector3(16.5f, 0, 20);


    // Start is called before the first frame update
    void Start()
    { 
        if (GetComponent<BossStages>().Stage == 0)
        {
            gameObject.transform.position = new Vector3(70, 0, 50);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<BossStages>().Stage == 0)
        {

            if (Estage == 1)
            {

                transform.position += Time.deltaTime * 60.0f * -gameObject.transform.right;

                if(gameObject.transform.position.x < -55)
                {

                    gameObject.transform.position = new Vector3(-30, 0, 10);
                    Estage = 2;
                }

            }

            if(Estage == 2)
            {

                transform.position += Time.deltaTime * 35.0f * gameObject.transform.right;

                if (gameObject.transform.position.x > 35)
                {

                    gameObject.transform.position = new Vector3(40, 0, 20);
                    Estage = 3;
                }

            }
            if(Estage == 3)
            {

                float dist = Vector3.Distance(endPos, transform.position);
                float speed = Mathf.Pow(dist, 1.3f) + 5;
                float step = speed * Time.deltaTime;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPos, step);

                if(gameObject.transform.position.x == 16.5)
                {

                    GetComponent<BossStages>().Stage = 1;

                }

            }

        }
    }
}
