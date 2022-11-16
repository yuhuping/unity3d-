using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    public Material outlineMaterial;
    private float outlineScaleFactor;
    private Color outlineColor;
    private Renderer outlineRenderer;

    private Renderer rend;
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        //outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
        //outlineRenderer.enabled = false;
    }
    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend = outlineObject.GetComponent<Renderer>();

        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineScript>().enabled = false;
        //outlineObject.GetComponent<Collider>().enabled = false;

        rend.enabled = false;

        return rend;
    }

    public void setoutline()
    {
        //outlineRenderer.material.SetFloat("_Scale", 0);
        rend.material = outlineMaterial;
        rend.material.SetFloat("_Scale", 0);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        Invoke("setoutlinefalse", 0.5f);
    }
    public void setoutlinefalse()
    {
        rend.material = outlineMaterial;
        rend.material.SetFloat("_Scale", -1.1f);
    }
}
