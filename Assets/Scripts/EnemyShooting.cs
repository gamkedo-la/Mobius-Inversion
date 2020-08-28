using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject shotPrefab;
    public AudioSource shotAudio;
    public AudioClip   shotClip;
    public float shotVolume=0.5f;
    public float shootRate;
    public int ammoCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {       
        while (true)
        {
            yield return new WaitForSeconds(shootRate);
            //Debug.Log("Battle False!");
            if (transform.position.x < Bounds.instance.rightX)
            {
                ammoCount--;
                if (ammoCount < 0)
                {
                    yield break;
                }
                GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation * Quaternion.AngleAxis(0.0f, Vector3.up));
                shotAudio.PlayOneShot(shotClip, shotVolume*Random.Range(0.1f,2f));

               
            }      
        }
       
    }
}
