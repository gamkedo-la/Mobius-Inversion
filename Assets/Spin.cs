using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinRate = 30.0f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinRate * Time.deltaTime);
    }
}
