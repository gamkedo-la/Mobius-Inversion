using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyMoving : MonoBehaviour
{
    public Transform[] waypointList;
    private Vector3 pos1 = new Vector3(18, -15, 20);
    private Vector3 pos2 = new Vector3(18, 15, 20);
    public float speed = 5.0f;
    private int currentWayPoint = 0;
    private float progressPerk = 0.0f;

    public AnimationCurve speedCurve;

    public class FollowCurve : EditorWindow
    {
        AnimationCurve curveX = AnimationCurve.Linear(0, 0, 10, 10);
        AnimationCurve curveY = AnimationCurve.Linear(0, 0, 10, 10);
        AnimationCurve curveZ = AnimationCurve.Linear(0, 0, 10, 10);

        [MenuItem("Examples/Create Curve For Object")]
        static void Init()
        {
            FollowCurve window = (FollowCurve)EditorWindow.GetWindow(typeof(FollowCurve));
            window.Show();
        }

        void OnGUI()
        {
            curveX = EditorGUILayout.CurveField("Animation on X", curveX);
            curveY = EditorGUILayout.CurveField("Animation on Y", curveY);
            curveZ = EditorGUILayout.CurveField("Animation on Z", curveZ);

            if (GUILayout.Button("Generate Curve"))
                AddCurveToSelectedGameObject();
        }

        void AddCurveToSelectedGameObject()
        {
            if (Selection.activeGameObject)
            {
                //FollowAnimationCurve comp =
                //    Selection.activeGameObject.AddComponent<FollowAnimationCurve>();

                //comp.SetCurves(curveX, curveY, curveZ);
            }
            else
            {
                Debug.LogError("No Game Object selected for adding an animation curve");
            }
        }
    }

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
        float smoothPerk = Ease(progressPerk);
        Vector3 pos = Vector3.Lerp(waypointList[currentWayPoint].position, waypointList[currentWayPoint + 1].position, smoothPerk);     
        Quaternion rot = Quaternion.Slerp(waypointList[currentWayPoint].rotation, waypointList[currentWayPoint + 1].rotation, smoothPerk);
        transform.position = pos;
        transform.rotation = rot;
    }    

    private float Ease(float inValue)
    {
        return inValue * inValue;
    }

	public void OnDrawGizmosSelected() {
		if (waypointList.Length <= 0) return;

		//Would be cleaner if this just pointed to the "waypoint set" instead of manually defining every waypoint in a public array
		/*
		GameObject waypointset = waypointList[0].transform.parent.gameObject;
		//waypointset.GetComponent<WaypointSetGizmo>().DrawWaypointPath();
		*/
		
		int length = waypointList.Length;
		Gizmos.color = Color.red;
		for (int i = 0; i < length; i++) {
			if (i < length - 1) Gizmos.DrawLine(waypointList[i].position, waypointList[i + 1].position);
			Gizmos.DrawSphere(waypointList[i].position, 0.5f);
		}
	}
}

