using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject enemyExplosion;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
                        
            Instantiate(enemyExplosion, transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
        
    }
 }
