using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementStage2 : MonoBehaviour
{
    public Vector3 Target;
    public GameObject bombPrefab;
    public GameObject bulletPrefab;

    public Vector3 bombLauncher;

    public Transform bulletWave1;
    public Transform bulletWave2;
    public Transform bulletWave3;
    public Transform bulletWave4;


    public float speed;
    float step;
    public float mod = 20;
    public float POW;

    public float dist;

    float timer = 4.0f;
    float timerReset;


    // Start is called before the first frame update
    void Start()
    {
        Target = gameObject.transform.position;

        Destination();

        timerReset = timer;

        bombLauncher = gameObject.transform.position;
        bombLauncher.x -= 5;

        



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

            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {


                GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletWave1.position, Quaternion.identity);
                bullet = (GameObject)Instantiate(bulletPrefab, bulletWave2.position, Quaternion.identity);
                bullet = (GameObject)Instantiate(bulletPrefab, bulletWave3.position, Quaternion.identity);
                bullet = (GameObject)Instantiate(bulletPrefab, bulletWave4.position, Quaternion.identity);



                timer = timerReset;

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
