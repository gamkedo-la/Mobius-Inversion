using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRaycast : MonoBehaviour
{

    public MeshRenderer renderer;
    public Material instancedMaterial;
    private float timeDecrease;
    public float rateDecay;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        instancedMaterial = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDecrease >= 0)
         {
        timeDecrease -= Time.deltaTime*rateDecay ;
        instancedMaterial.SetFloat("_HitFade", timeDecrease);
        }
    }

    public void SetHitPosition(Vector3 hitPosition, float decayTime)
    {
       /*  print(hitPosition); */
       /*  print (decayTime); */
        Vector3 hitVector = gameObject.transform.InverseTransformPoint(hitPosition);
        instancedMaterial.SetVector("_BulletHit", hitVector);
        instancedMaterial.SetFloat("_HitFade", decayTime);
        timeDecrease = decayTime;
    }


}
