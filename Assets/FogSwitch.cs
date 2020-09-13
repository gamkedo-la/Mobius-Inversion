using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSwitch : MonoBehaviour
{
    public bool FogOn = true;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = FogOn;

        //Debug.Log("Fog Enabled by Script " + (RenderSettings.fog ? "There is Fog " : "There is not Fog"));
    }
}
