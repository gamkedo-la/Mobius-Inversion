using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(EnemyGridSpawnerTool))]
public class GridSpawnInspector : Editor
{

    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        EnemyGridSpawnerTool myEnemyGridSpawnerTool = (EnemyGridSpawnerTool)target;

        /*
        myEnemyGridSpawnerTool.columns = EditorGUILayout.IntField("Columns", myEnemyGridSpawnerTool.columns);

        myEnemyGridSpawnerTool.HorizontalSpacing = EditorGUILayout.FloatField("Horizontal Spacing", myEnemyGridSpawnerTool.HorizontalSpacing);

        myEnemyGridSpawnerTool.rows = EditorGUILayout.IntField("Rows", myEnemyGridSpawnerTool.rows);
        myEnemyGridSpawnerTool.VerticalSpacing = EditorGUILayout.FloatField("Vertical Spacing", myEnemyGridSpawnerTool.VerticalSpacing);
        */


        if (GUILayout.Button("Preview Spawns"))
        {
            myEnemyGridSpawnerTool.spawnGrid();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
