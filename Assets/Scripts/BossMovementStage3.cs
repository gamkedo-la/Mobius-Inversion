using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementStage3 : MonoBehaviour
{

    GameObject Target;
    int Index;
    Vector2 EndPosition = new Vector2(0, 0);
    public float ShotTimer = 0.2f;
    public float ShotTimerReset = 0.2f;
    public float TargetTimer = 0.8f;
    public float TargetTimerReset = 0.8f;

    public float speed;

    float dist;

    public float POW;
    public float mod;
    float step;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        EndPosition = gameObject.transform.position;
        SelectTarget();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<BossStages>().Stage == 3)
        {

            EndPosition.y = Target.transform.position.y;



            dist = Vector3.Distance(EndPosition, transform.position);
            speed = Mathf.Pow(dist, POW) + mod;
            step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, EndPosition, step);

            if(ShotTimer <= 0)
            {
                Shoot();
                ShotTimer = ShotTimerReset;

            }

            if(TargetTimer <= 0)
            {
                SelectTarget();
                TargetTimer = TargetTimerReset;

            }
            TargetTimer -= Time.fixedDeltaTime;
            ShotTimer -= Time.fixedDeltaTime;


        }
    }


    void SelectTarget()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        Index = (Random.Range(0, players.Length) - 1);

        Target = players[Index];


    }

    void Shoot()
    {

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);

    }

}
