using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public static Bounds instance;

    public GameObject leftEdge;
    public GameObject rightEdge;
    public GameObject topEdge;
    public GameObject bottomEdge;

    public float leftX = 0.0f;
    public float rightX = 0.0f;
    public float topY = 0.0f;
    public float bottomY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        leftX = leftEdge.transform.position.x;
        rightX = rightEdge.transform.position.x;
        topY = topEdge.transform.position.y;
        bottomY = bottomEdge.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
