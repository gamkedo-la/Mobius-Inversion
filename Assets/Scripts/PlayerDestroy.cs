using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject enemyExplosion;
    public AudioSource shotAudio;
    public AudioClip   shotClip;
    public float shotVolume=0.5f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullets"))
        {
                        
            Instantiate(enemyExplosion, transform.position,transform.rotation);
            shotAudio.PlayOneShot(shotClip, shotVolume*Random.Range(0.8f,1.2f));
            Destroy(gameObject,1);
            Destroy(other.gameObject);
            
        }
        
    }
 }
