using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public GameObject[] shipList;
    public GameObject healingZone;
    public float healingZoneRadius = 3.25f;
    private float previousHealingZoneRadius;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        shipList = GameObject.FindGameObjectsWithTag("Player");
        healingZone = GameObject.FindGameObjectWithTag("HealingZone");
    }

    // Update is called once per frame
    void Update()
    {
        if(previousHealingZoneRadius != healingZoneRadius)
        {
            previousHealingZoneRadius = healingZoneRadius;
            healingZone.transform.localScale = Vector3.one * 2.0f * healingZoneRadius;
        }
        for (int i = 0; i < shipList.Length; i++)
        {
            if(shipList[i] != gameObject)
            {
                float dist = Vector2.Distance(transform.position, shipList[i].transform.position);
                if(dist < healingZoneRadius)
                {
                    Debug.Log("Healing Ship" + shipList[i].name);               
                }
            }
        }
    }
    
}
