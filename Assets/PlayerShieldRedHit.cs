using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldRedHit : MonoBehaviour
{
    public HealthBarScript shieldbar;
    public PlayerHealth shieldMaxHealth;
    public PlayerHealth shieldCurrentHealth;
    public GameObject enemyExplosion;

    public float decaytime;
    public ShieldRaycast shieldRaycast;

    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullets"))
        {
            Debug.Log(other.gameObject.name);
            //Instantiate(enemyExplosion, other.transform.position, transform.rotation);
            //decaytime = 3f;
            Vector3 shieldhit = other.gameObject.transform.position; 
            shieldhit.z = other.transform.position.z; 
            shieldRaycast.SetHitPosition(shieldhit, decaytime);
            Destroy(other.gameObject);
        }
    }
}