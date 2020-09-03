using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipColor { Green, Yellow, Red, Purple };

public class PlayerControl : MonoBehaviour
{
    public GameObject shotPrefab;
	[SerializeField] private Vector2 boundaryPadding = new Vector2(15.0f, 10.0f);

    public float horizSpeed = 14.0f;
    public float vertSpeed = 11.3f;

    public float rateOfFire;

    public bool isDead = false;
    private Renderer myRend;

	private Camera mainCamera;
    private Vector3 startPos;

    public HealthBarScript healthBar;
    public int maxHealth = 100;

    GameObject playerBody;

    public bool debugWontFire = false;

    
    public ShipColor thisShip;
    public ShipColor activeShip;

    public AudioSource shotAudio;
    public AudioClip   shotClip;
    public float shotVolume=0.5f;

    public static event Action<PlayerControl> StatsOnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
		mainCamera = (Camera) GameObject.FindWithTag("MainCamera").GetComponent(typeof(Camera));
        myRend = GetComponentInChildren<Renderer>();
        startPos = transform.position;
        if(debugWontFire == false)
        {
            StartCoroutine(AutoShoot());
        }        
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

        if (activeShip == thisShip)
        {

            transform.position += Vector3.up * Input.GetAxis("Vertical") * vertSpeed * Time.deltaTime +
                    Vector3.right * Input.GetAxis("Horizontal") * horizSpeed * Time.deltaTime;

            transform.position = ClampToScreen(transform.position, mainCamera, boundaryPadding);
        }

        /*if(Input.GetKeyDown(KeyCode.Space)) {        
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha1)) { activeShip = ShipColor.Green; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { activeShip = ShipColor.Yellow; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { activeShip = ShipColor.Red; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { activeShip = ShipColor.Purple; }


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
	

    public void DeathCheckThenRespawn(bool deadNow)
    {
        if(isDead) //blocking it from happening if already dead
        {
            return;
        }
        isDead = deadNow;

        if (isDead) //handling newly dead
        {
            StatsOnPlayerDeath(this);
            //Debug.Log("Turn off stuff");
            myRend.enabled = false;
            playerBody.SetActive(false);

            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn ()
    {
        yield return new WaitForSeconds(1.0f);

        isDead = false;
        Debug.Log("Turn on stuff");
        myRend.enabled = true;
        playerBody.SetActive(true);
        transform.position = startPos;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        while (isDead == false)
        {
            GameObject shotGO = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity, transform.parent);
            shotGO.GetComponent<PlayerShot>().FiredFrom = thisShip;

            yield return new WaitForSeconds(rateOfFire);
            shotAudio.PlayOneShot(shotClip, shotVolume * UnityEngine.Random.Range(0.5f, 1.5f));
        }
    }
}
