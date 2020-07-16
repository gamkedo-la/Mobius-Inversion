using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExplode : MonoBehaviour
{
    public Material Renderer;
    public GameObject BombObject;
    public GameObject Particle;
    public Color baseColor;
    public Color changeColor;


    private void Start()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        Renderer.color = baseColor;
        yield return new WaitForSeconds(2);
        Renderer.color = changeColor;
        yield return new WaitForSeconds(.5f);
        Renderer.color = baseColor;
        yield return new WaitForSeconds(.5f);
        Renderer.color = changeColor;
        yield return new WaitForSeconds(.25f);
        Renderer.color = baseColor;
        yield return new WaitForSeconds(.25f);
        Renderer.color = changeColor;
        yield return new WaitForSeconds(.125f);
        Renderer.color = baseColor;
        yield return new WaitForSeconds(.125f);
        Renderer.color = changeColor;
        yield return new WaitForSeconds(.05f);
        Renderer.color = baseColor;
        yield return new WaitForSeconds(.05f);
        Renderer.color = changeColor;
        yield return new WaitForSeconds(.5f);
        Particle.SetActive(true);
        BombObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
