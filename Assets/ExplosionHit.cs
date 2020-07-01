using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHit : MonoBehaviour
{
    [SerializeField]
    private float force = 20.0f;
     [SerializeField]
    private float spin = 3.0f;
    [SerializeField]
    private Rigidbody2D enemyPart1;
    [SerializeField]
    private Rigidbody2D enemyPart2;
    void Awake()
    {
        //assumes parts are going to only use 2D physics
        enemyPart1.AddForce(Random.insideUnitCircle.normalized*force, ForceMode2D.Impulse);
        enemyPart1.AddTorque(spin, ForceMode2D.Impulse);
        enemyPart2.AddForce(Random.insideUnitCircle.normalized*force, ForceMode2D.Impulse);
        enemyPart2.AddTorque(-spin, ForceMode2D.Impulse);
    }
    
    void OnParticleSystemStopped()
    {
          Destroy(gameObject);
    }
    
}
