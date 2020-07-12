using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyGridSpawnerTool : MonoBehaviour
{

    public GameObject enemy;
    public int columns;
    public float HorizontalSpacing;
    public int rows;
    public float VerticalSpacing;

    public Transform Waypoints;

    List<GameObject> kids;

    Vector3 temp = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in gameObject.transform)
        {
            kids.Add(child.gameObject);
        }

        foreach (GameObject child in kids)
        {
            DestroyImmediate(child);
        }

        spawnGrid();

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnGrid()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.DestroyImmediate(child.gameObject);
        }

        temp = gameObject.transform.position;

        for (int c = 1; c <= columns; c++)
        {

            for (int r = 0; r < rows; r++)
            {

                GameObject E = (GameObject)Instantiate(
                           enemy,
                           temp,
                           Quaternion.identity,
                           gameObject.transform);

                if (E.GetComponent<EnemyMoving>() != null)
                {
                    E.GetComponent<EnemyMoving>().waypointSet = Waypoints;
                }
                temp.y -= VerticalSpacing;

            }
            temp = gameObject.transform.position;
            temp.x += (c * HorizontalSpacing);
        }
    }


}
