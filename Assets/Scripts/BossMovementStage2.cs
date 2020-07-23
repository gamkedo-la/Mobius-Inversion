using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementStage2 : MonoBehaviour
{
    public Vector3 Target;
    public GameObject bombPrefab;

    public Vector3 bombLauncher;


    public float speed;
    float step;
    public float mod = 20;
    public float POW;

    public float dist;


    // Start is called before the first frame update
    void Start()
    {
        Target = gameObject.transform.position;

        Destination();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GetComponent<BossStages>().Stage == 2)
        {

            dist = Vector3.Distance(Target, transform.position);

            if (dist <= 0.1f)
            {

                bombLauncher = gameObject.transform.position;
                bombLauncher.x -= 5;

                GameObject bomb = (GameObject)Instantiate(bombPrefab, bombLauncher, Quaternion.identity);

                Destination();

            }
            else
            {

                speed = Mathf.Pow(dist, POW) + mod;

                step = speed * Time.deltaTime;

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target, step);

            }
        }

    }

    void Destination()
    {

        int ytemp = Random.Range(-8, 8);

        Target.y = ytemp;

        return;

    }
}
