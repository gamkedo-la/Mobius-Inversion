using UnityEngine;
public class WaypointSetGizmo : MonoBehaviour
{
	private Transform[] waypoints;

	public void OnDrawGizmosSelected() {
		DrawWaypointPath();
	}

	public void DrawWaypointPath() {
		waypoints = GetComponentsInChildren<Transform>();
		int length = waypoints.Length;
		Gizmos.color = Color.red;
		for (int i = 0; i < length; i++) {
			if (i < length - 1) Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
			Gizmos.DrawSphere(waypoints[i].position, 0.5f);
		}
	}
}
