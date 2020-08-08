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
           Vector3 audiolocation = transform.position;
           audiolocation.z = -10;           
            Instantiate(enemyExplosion, transform.position,transform.rotation);
            //AudioSource.PlayClipAtPoint(shotClip, audiolocation ,shotVolume*Random.Range(0.8f,1.2f));
           //Destroy(gameObject);
           //Think above plays but very quietly, need to check where in 3d space this is actually playing is it too far from camera to here?
           //Try writing in camera vector 3 to see if plays at expected volume
            shotAudio.PlayOneShot(shotClip, shotVolume*Random.Range(0.8f,1.2f));
            Destroy(gameObject,1);
            Destroy(other.gameObject);
            
        }
        
    }
 }
