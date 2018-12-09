using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLight : MonoBehaviour {

    public Material matButtonOn;
    public Material matButtonOff;
    public Renderer meshRendererButton;

    private Light light;

	void Start () {
        light = GetComponentInChildren<Light>();
	}
	
	public void ActivateLight()
    {
        light.enabled = true;
        meshRendererButton.material.color = Color.green;
    }

    public void DesactivateLight()
    {
        light.enabled = false;
        meshRendererButton.material.color = Color.red;
    }
}
