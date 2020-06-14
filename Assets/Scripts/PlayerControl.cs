using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject shotPrefab;
	[SerializeField] private Vector2 boundaryPadding = new Vector2(15.0f, 10.0f);

    private float horizSpeed = 14.0f;
    private float vertSpeed = 11.3f;

    public bool isDead = false;
    private Renderer myRend;

	private Camera mainCamera;
    private Vector3 startPos;

    GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
		mainCamera = (Camera) GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera));
        myRend = GetComponentInChildren<Renderer>();
        startPos = transform.position;
        StartCoroutine(AutoShoot());
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
        playerBody.SetActive(true);
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

		transform.position = ClampToScreen(transform.position, mainCamera, boundaryPadding);
		
		/*if(Input.GetKeyDown(KeyCode.Space)) {        
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
        }*/

		if (Input.GetButtonUp("Pause")) 
		{
			TogglePause();
		}
    }

	Vector3 ClampToScreen(Vector3 position, Camera camera, Vector2 padding) {
		Vector3 screenPosition = camera.WorldToScreenPoint(position);
		Vector3 clampedPosition = new Vector3(Mathf.Clamp(screenPosition.x, padding.x, camera.pixelWidth - padding.x), 
											Mathf.Clamp(screenPosition.y, padding.x, camera.pixelHeight - padding.y), screenPosition.z);
		
		return camera.ScreenToWorldPoint(clampedPosition);
	}

	void TogglePause() 
	{
		if (Time.timeScale > 0) Time.timeScale = 0;
		else Time.timeScale = 1.0f;
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if(isDead)
        {
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyBullets"))
        {
            DeathThenRespawn();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyShip"))
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
        playerBody.SetActive(false);

        StartCoroutine(Respawn());

    }

    IEnumerator Respawn ()
    {
        yield return new WaitForSeconds(1.0f);

        isDead = false;
        Debug.Log("Turn on stuff");
        myRend.enabled = true;
        playerBody.SetActive(true);
        transform.position = startPos;
        //StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        while (true && isDead == false)
        {
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity, transform.parent);
            yield return new WaitForSeconds(.5f);
        }
    }
}
