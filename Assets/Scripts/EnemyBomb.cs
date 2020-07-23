using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Time.deltaTime * 7.0f * -gameObject.transform.right;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {

            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject);

            Destroy(collision.gameObject);

            Debug.Log("Bullet collided with bomb, TO DO: ADD EXPLOSION VFX");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerShip"))
        {

            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject);

        }

    }
}
