using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public Transform[] waypointList;
    private Vector3 pos1 = new Vector3(18, -15, 20);
    private Vector3 pos2 = new Vector3(18, 15, 20);
    public float speed = 5.0f;
    private int currentWayPoint = 0;
    private float progressPerk = 0.0f;


    void Update()
    {
        if(transform.position.x > Bounds.instance.rightX)
        {
            return; //off the right side of the screen            
        }
        progressPerk += Time.deltaTime * speed;
        if(progressPerk >= 1.0f)
        {
            progressPerk -= 1.0f;
            currentWayPoint++;
        }
        if(currentWayPoint >= waypointList.Length - 1)
        {
            return;
        }
        Vector3 pos = Vector3.Lerp(waypointList[currentWayPoint].position, waypointList[currentWayPoint + 1].position, progressPerk);     
        Quaternion rot = Quaternion.Slerp(waypointList[currentWayPoint].rotation, waypointList[currentWayPoint + 1].rotation, progressPerk);
        transform.position = pos;
        transform.rotation = rot;
    }
}

