using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointSetGizmo : MonoBehaviour
{
	private Transform[] waypoints;

	public void OnDrawGizmosSelected() {
		waypoints = GetComponentsInChildren<Transform>();
		Debug.Log(waypoints);
		int length = waypoints.Length;
		Gizmos.color = Color.red;
		for (int i = 0; i < length; i++) {
			//Gizmos.DrawSphere(waypoints[i].position, 1);
			if (i < length - 1) Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
			else break;
		}
	}
}
