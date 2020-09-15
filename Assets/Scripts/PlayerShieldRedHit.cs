using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldRedHit : MonoBehaviour
{
    public HealthBarScript shieldbar;
    public PlayerHealth shieldMaxHealth;
    public PlayerHealth shieldCurrentHealth;
    public GameObject enemyExplosion;
    public PlayerHealth healingUp;
    public GameObject blueShip;
    public Transform blueShipTransform;

    public float decaytime;
    public ShieldRaycast shieldRaycast;

    void Start()
    {
        //healingUp.GetComponentInParent<PlayerHealth>();
        //blueShipTransform = blueShip.transform.position;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullets"))
        {
            //healingUp.Heal(10);
            Vector3 shieldhit = other.gameObject.transform.position; 
            shieldhit.z = other.transform.position.z + Random.Range(-2.0f,1.0f); 
            shieldRaycast.SetHitPosition(shieldhit, decaytime);
            Destroy(other.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {            
            Vector3 shieldhit = other.gameObject.transform.position;
            shieldhit.z = other.transform.position.z + Random.Range(-2.0f, 1.0f);
            shieldRaycast.SetHitPosition(shieldhit, decaytime);
            Destroy(other.gameObject);
        }
    }
}