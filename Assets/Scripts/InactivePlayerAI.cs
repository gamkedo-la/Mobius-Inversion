using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactivePlayerAI : MonoBehaviour
{

    ShipColor thisShipColor;

    public List<GameObject> EnemyList = new List<GameObject>();

    public List<GameObject> ShieldList = new List<GameObject>();

    GameObject Boss;

    GameObject Target;

    GameObject temp;


    // Start is called before the first frame update
    void Start()
    {

        thisShipColor = gameObject.GetComponent<PlayerControl>().thisShip;

        temp = null;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyList.Clear();
        ShieldList.Clear();

        Boss = GameObject.Find("Boss");


        if(gameObject.GetComponent<PlayerControl>().activeShip != thisShipColor)
        {
            if (Boss != null)
            {
                foreach (GameObject enObj in GameObject.FindGameObjectsWithTag("BossShield"))
                {
                    ShieldList.Add(enObj);
                }

                for( int i = 0; i < ShieldList.Count; i++)
                {

                    if(ShieldList[i].GetComponent<BossShield>().PassThrough == gameObject.GetComponent<PlayerControl>().thisShip)
                    {
                        Target = ShieldList[i];

                    }

                }
            }
            else
            {
                if (Target == null || Target.transform.position.x < gameObject.transform.position.x)
                {
                    foreach (GameObject enObj in GameObject.FindGameObjectsWithTag("Enemy"))
                    {

                        EnemyList.Add(enObj);
                    }

                    EnemyList.Sort(delegate (GameObject A, GameObject B)
                    {
                        return Vector2.Distance(this.transform.position, A.transform.position)
                          .CompareTo
                          (Vector2.Distance(this.transform.position, B.transform.position));
                    });

                    Target = EnemyList[Random.Range(0, 2)];

                }
            }

            if (Target != null)
            {
                Vector3 dest = new Vector3(gameObject.transform.position.x, Target.transform.position.y, 20);
            }
            else
            {
                Vector3 dest = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + Random.Range(-3,3)), 20);

            }

            float step = gameObject.GetComponent<PlayerControl>().vertSpeed * Time.deltaTime * 0.7f;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, dest, step);



        }

        
    }
}
