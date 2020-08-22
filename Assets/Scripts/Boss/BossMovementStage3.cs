using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementStage3 : MonoBehaviour
{

    GameObject Target;
    int Index;
    Vector3 EndPosition = new Vector3(0, 0, 0);
    public float ShotTimer = 0.2f;
    public float ShotTimerReset = 0.2f;
    public float TargetTimer = 0.8f;
    public float TargetTimerReset = 0.8f;

    public float specialAttackTimer = 4.0f;
    float specialAttackTimerReset;

    public int specialAttackState = 1;

    public float speed;

    float dist;

    public float POW;
    public float mod;
    float step;

    public float specialAttackSpeed;

    public GameObject bulletPrefab;
    public GameObject homingMisslePrefab;

    public Vector3 top = new Vector3(16, 5, 20);
    public Vector3 bottom = new Vector3(16, -5,20);
    public Vector3 back = new Vector3(16,0,20);


    public Transform bulletWave1;
    public Transform bulletWave2;
    public Transform bulletWave3;
    public Transform bulletWave4;

    public GameObject[] players;


    // Start is called before the first frame update
    void Start()
    {
        EndPosition = gameObject.transform.position;
        SelectTarget();

        specialAttackTimerReset = specialAttackTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<BossStages>().Stage == 3)
        {
            if (specialAttackState == 1)
            {
                EndPosition.y = Target.transform.position.y;

                dist = Vector3.Distance(EndPosition, transform.position);
                speed = Mathf.Pow(dist, POW) + mod;
                step = speed * Time.deltaTime;
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, EndPosition, step);

                if (ShotTimer <= 0)
                {
                    Shoot();
                    ShotTimer = ShotTimerReset;

                }

                if (TargetTimer <= 0)
                {
                    SelectTarget();
                    TargetTimer = TargetTimerReset;

                }

                specialAttackTimer -= Time.fixedDeltaTime;

                if (specialAttackTimer <= 0)
                {

                    specialAttackState = 2;
                    specialAttackTimer = specialAttackTimerReset;

                }
                

            }
            if (specialAttackState  == 2)
            {

                
                step = specialAttackSpeed * Time.deltaTime;


                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, top, step);

                if (Vector3.Distance(top, transform.position) < 0.1f)
                {


                    GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletWave1.position, Quaternion.identity);
                    bullet = (GameObject)Instantiate(bulletPrefab, bulletWave2.position, Quaternion.identity);
                    bullet = (GameObject)Instantiate(bulletPrefab, bulletWave3.position, Quaternion.identity);
                    bullet = (GameObject)Instantiate(bulletPrefab, bulletWave4.position, Quaternion.identity);
                    GameObject homingMissile = (GameObject)Instantiate(homingMisslePrefab, gameObject.transform.position, Quaternion.identity);

                    specialAttackState = 3;

                }

            }
            if (specialAttackState == 3)
            {
                
                step = specialAttackSpeed * Time.deltaTime;

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, bottom, step);

                if (Vector3.Distance(bottom, transform.position) < 0.1f)
                {

                    GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletWave1.position, Quaternion.identity);
                    bullet = (GameObject)Instantiate(bulletPrefab, bulletWave2.position, Quaternion.identity);
                    bullet = (GameObject)Instantiate(bulletPrefab, bulletWave3.position, Quaternion.identity);
                    bullet = (GameObject)Instantiate(bulletPrefab, bulletWave4.position, Quaternion.identity);
                    GameObject homingMissile = (GameObject)Instantiate(homingMisslePrefab, gameObject.transform.position, Quaternion.identity);



                    specialAttackState = 4;

                }

            }
            if (specialAttackState == 4)
            {
                
                step = specialAttackSpeed * Time.deltaTime;

                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, back, step);

                if (Vector3.Distance(back, transform.position) < 0.1f)
                {

                    specialAttackState = 1;

                }


            }

            TargetTimer -= Time.fixedDeltaTime;
            ShotTimer -= Time.fixedDeltaTime;


        }
    }


    void SelectTarget()
    {
        
        

        Index = (Random.Range(0, 3));

        Target = players[Index];


    }

    void Shoot()
    {

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);

    }

}
