using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDestroy : MonoBehaviour
{
    public GameObject enemyExplosion;
    public AudioSource shotAudio;
    public AudioClip   shotClip;
    public float shotVolume=0.5f;

    public int scoreValue = 100; // How many points this object is worth
    public static event Action<PlayerShot, int> StatsOnPlayerDestroyEnemy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
           Vector3 audiolocation = transform.position;
           audiolocation.z = -10;           
            Instantiate(enemyExplosion, transform.position,transform.rotation);
            //AudioSource.PlayClipAtPoint(shotClip, audiolocation ,shotVolume*Random.Range(0.8f,1.2f));
            //Destroy(gameObject);
            //Think above plays but very quietly, need to check where in 3d space this is actually playing is it too far from camera to here?
            //Try writing in camera vector 3 to see if plays at expected volume
            shotAudio.PlayOneShot(shotClip, shotVolume * UnityEngine.Random.Range(0.8f, 1.2f));
            Destroy(gameObject,1); // The enemy this script is attached to
            Destroy(other.gameObject); // The bullet that collided with this object

            // Check the bullet is from a player and call event to update stats
            if (other.gameObject.GetComponent<PlayerShot>() != null)
            {
                StatsOnPlayerDestroyEnemy(other.gameObject.GetComponent<PlayerShot>(), scoreValue);
            }
        }
        
    }
 }
