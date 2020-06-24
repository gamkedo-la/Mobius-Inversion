using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {       
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            //Debug.Log("Battle False!");
            if (transform.position.x < Bounds.instance.rightX)
            {
                GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation);
            }      
        }
       
    }
}
