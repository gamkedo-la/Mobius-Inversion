using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject shotPrefab;

    private float horizSpeed = 14.0f;
    private float vertSpeed = 11.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Input.GetAxis("Vertical") * vertSpeed * Time.deltaTime +
                Vector3.right * Input.GetAxis("Horizontal") * horizSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
        }
    }
}
