using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    GameObject Target;
    public float speed;
    float step;



    // Start is called before the first frame update
    void Start()
    {

        //Destroy(gameObject, 4.0f);

        Target = Targeting();
    }

    // Update is called once per frame
    void Update()
    {

        step = speed * Time.deltaTime;

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position, step);

        transform.LookAt(Target.transform);

    }

    public GameObject Targeting()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        return closest;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);

            Debug.Log("homing missle destroyed by player bullet, TO DO: ADD EXPLOSION VFX");
        }
    }

}
