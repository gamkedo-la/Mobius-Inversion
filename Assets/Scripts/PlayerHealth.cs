using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject enemyExplosion;
    public int maxHealth = 100;
    public int currentHealth;
    private PlayerControl pcScript;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GetComponent<PlayerControl>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Player touched by " + other.gameObject.name);

        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullets"))
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            TakeDamage(20);
            Destroy(other.gameObject);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyShip"))
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log("Health now is " + currentHealth);
        healthBar.SetHealth(currentHealth);
        pcScript.DeathCheckThenRespawn(currentHealth<=0);       
    }
}
