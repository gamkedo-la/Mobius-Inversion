using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject shotPrefab;

    private float horizSpeed = 14.0f;
    private float vertSpeed = 11.3f;

    private bool isDead = false;
    private Renderer myRend;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponentInChildren<Renderer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }

        transform.position += Vector3.up * Input.GetAxis("Vertical") * vertSpeed * Time.deltaTime +
                Vector3.right * Input.GetAxis("Horizontal") * horizSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(isDead)
        {
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullets"))
        {
            DeathThenRespawn();
        }
    }

    void DeathThenRespawn()
    {
        if(isDead)
        {
            return;
        }

        isDead = true;
        Debug.Log("Turn off stuff");
        myRend.enabled = false;

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn ()
    {
        yield return new WaitForSeconds(1.0f);

        isDead = false;
        Debug.Log("Turn on stuff");
        myRend.enabled = true;
        transform.position = startPos;
    }
}
