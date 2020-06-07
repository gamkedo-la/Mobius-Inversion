using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyMoving : MonoBehaviour
{
    public Transform waypointSet;
    private List<Transform> waypointList;
    private Vector3 pos1 = new Vector3(18, -15, 20);
    private Vector3 pos2 = new Vector3(18, 15, 20);
    public float speed = 5.0f;
    private int currentWayPoint = 0;
    private float progressPerk = 0.0f;

    public AnimationCurve speedCurve;
    private WaypointData currentWayPointData = null;
    private WaypointData nextWayPointData = null;

    public float speedPerkHere;

    void Start()
    {
        waypointList = new List<Transform>();
        //Debug.Log(gameObject.name + " " + (waypointSet != null));
        for(int i = 0; i < waypointSet.childCount; i++)
        {
            waypointList.Add(waypointSet.GetChild(i));
        }
        UpdateCurrentIndexedWaypoint();
    }

    void UpdateCurrentIndexedWaypoint()
    {
        if (currentWayPoint < waypointList.Count)
        {
            currentWayPointData = waypointList[currentWayPoint].GetComponent<WaypointData>();
            if (currentWayPoint < waypointList.Count - 1)
            {
                nextWayPointData = waypointList[currentWayPoint + 1].GetComponent<WaypointData>();
            }
        }
    }

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
        float smoothPerk = Ease(progressPerk);

        speedPerkHere = Mathf.Lerp(currentWayPointData.speedPerc, nextWayPointData.speedPerc, progressPerk);
        
        progressPerk += Time.deltaTime * speed * speedPerkHere;
        if(progressPerk >= 1.0f)
        {
            progressPerk -= 1.0f;
            currentWayPoint++;
            UpdateCurrentIndexedWaypoint();
        }
        if(currentWayPoint >= waypointList.Count - 1)
        {
            return;
        }
        
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
		if (waypointList.Count <= 0) return;

		//Would be cleaner if this just pointed to the "waypoint set" instead of manually defining every waypoint in a public array
		/*
		GameObject waypointset = waypointList[0].transform.parent.gameObject;
		//waypointset.GetComponent<WaypointSetGizmo>().DrawWaypointPath();
		*/
		
		int length = waypointList.Count;
		Gizmos.color = Color.red;
		for (int i = 0; i < length; i++) {
			if (i < length - 1) Gizmos.DrawLine(waypointList[i].position, waypointList[i + 1].position);
			Gizmos.DrawSphere(waypointList[i].position, 0.5f);
		}
	}
}

