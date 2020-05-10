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
        while(true)
        {
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
