using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHit : MonoBehaviour
{
   

    void Awake()
    {
        //Add in impulse to enemy craft parts
    }
    
    void OnParticleSystemStopped()
    {
          Destroy(gameObject);
    }
    
}
