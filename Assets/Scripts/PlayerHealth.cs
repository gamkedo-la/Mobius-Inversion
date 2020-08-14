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
    //public float shieldTimeUp = 1.0f;
    //private float shieldLastTime = 4.0f;
    private PlayerShieldRedHit shield;
    public int shieldMaxHealth;
    public int shieldCurrentHealth;
    public float shieldRegen;
    public GameObject gameObjectShield;


    // Start is called before the first frame update
    void Start()
    {
        pcScript = GetComponent<PlayerControl>();
        shield = GetComponentInChildren<PlayerShieldRedHit>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //gameObjectShield = GameObject.Find("/Players&UI/PlayerShipBlue/PlayerShield");
        //gameObjectShield = shield.gameObject;
        if (shield)
        {
            shield.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shield)
        {
            if (Input.GetKey(KeyCode.E))
            {
                shield.gameObject.SetActive(true);
            }
            else
            {
                shield.gameObject.SetActive(false);
            }
        }

        /*
        if(shield && shieldTimeUp > 0)
        {
            shieldTimeUp -= Time.deltaTime / shieldLastTime;
            if(shieldTimeUp <= 0)
            {
                shield.gameObject.SetActive(false);
            }
        }*/
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Player touched by " + other.gameObject.name);

        if (shieldCurrentHealth > 0)
        {
            return;
        }

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
