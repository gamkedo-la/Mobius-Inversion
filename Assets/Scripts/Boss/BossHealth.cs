using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int HitPoints = 100;

    public int Stage;


    public AudioSource hitAudio;
    public AudioClip hitClip;
    public AudioClip deflectClip;
    //public float hitVolume = 0.5f;
    public float hitVolume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void TakeDamage()
    {
        HitPoints -= 10;
        Debug.Log("Damaging Boss");
        //hitAudio.PlayOneShot(hitClip, hitVolume * Random.Range(0.5f, 1.5f));
        hitAudio.PlayOneShot(hitClip, hitVolume);

        if (HitPoints <= 0)
        {

            Destroy(gameObject);

        }
    }


   

    void OnCollisionEnter2D(Collision2D other)
    {



        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {


            if (GameObject.Find("Boss").GetComponent<BossStages>().Stage == Stage)
            {
                TakeDamage();
            }
            else
            {

                hitAudio.PlayOneShot(deflectClip, hitVolume * Random.Range(0.5f, 1.5f));
            }



            Destroy(other.gameObject);

           

        }

    }

}
