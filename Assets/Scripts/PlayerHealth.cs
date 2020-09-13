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
    private HealingZone healingzone;
    public int shieldMaxHealth;
    public int shieldCurrentHealth;
    public float shieldRegen;
    public GameObject gameObjectShield;
    public float waitTime = 1.0f;
    public bool healActive;

    public GameObject gameObjectHeal;

    public GameObject healingParticles;

    public bool lowHealthStart = false;


    // Start is called before the first frame update
    void Start()
    {
        pcScript = GetComponent<PlayerControl>();
        shield = GetComponentInChildren<PlayerShieldRedHit>();
        healingzone = GetComponentInChildren<HealingZone>();
        //healingParticles = GameObject.Find("Players&UI/PlayerShipGreen/Healing Particles");
        healActive = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //gameObjectShield = GameObject.Find("/Players&UI/PlayerShipBlue/PlayerShield");
        //gameObjectShield = shield.gameObject;
        if(healingParticles)
        {
            healingParticles.gameObject.SetActive(false);
        }
        if (shield)
        {
            shield.gameObject.SetActive(false);
        }
        if (healingzone)
        {
            healingzone.gameObject.SetActive(false);
        }

        if (lowHealthStart)
        {
            currentHealth = 10;
            healthBar.SetHealth(currentHealth);
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

        if (healingzone)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                healActive = true;
                healingzone.gameObject.SetActive(true);
            }
            else
            {
                healActive = false;
                healingzone.gameObject.SetActive(false);
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


        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerShip"))
        {
            if (currentHealth < maxHealth)
            {
                Heal(10);
                //StartCoroutine(HealDelay(waitTime));
                if (healingParticles)
                {
                    healingParticles.gameObject.SetActive(true);
                }
                //StopCoroutine(HealDelay(waitTime));           
            }
        }
        
    }

    /*void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerShip"))
        {
            yield return StartCoroutine(HealDelay());
            if (healingParticles)
            {
                healingParticles.gameObject.SetActive(true);
            }
        }
    }*/

    void OnCollisionExit2D(Collision2D other)
    {
        StopCoroutine(HealDelay(waitTime));
        if (healingParticles)
        {
            healingParticles.gameObject.SetActive(false);
        }
    }

    void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log("Health now is " + currentHealth);
        healthBar.SetHealth(currentHealth);
        pcScript.DeathCheckThenRespawn(currentHealth<=0);       
    }

    public IEnumerator HealDelay(float waitTime)
    {
        while (true)
        {
            //Debug.Log("HealingDelay");
            Heal(10);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
