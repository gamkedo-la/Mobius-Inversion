using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public HealthBarScript shieldbar;
    public PlayerHealth shieldMaxHealth;
    public PlayerHealth shieldCurrentHealth;
    public GameObject enemyExplosion;

    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullets"))
        {
            Debug.Log(other.gameObject.name);
            Instantiate(enemyExplosion, other.transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
}