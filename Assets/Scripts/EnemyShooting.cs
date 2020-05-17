using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject shotPrefab;
    public bool battling = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > Bounds.instance.rightX)
        {
            return; //off the right side of the screen            
        }
        else
        {
            Debug.Log("Battle True!");
            StartCoroutine(AutoShoot());
        }
    }

    void Shooting()
    {
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        if (battling == false)
        {
            while (true)
            {
                battling = true;
                Debug.Log("Battle False!");
                GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.4f);
            }
        }           
    }
}
