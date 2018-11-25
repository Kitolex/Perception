using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLight : MonoBehaviour {

    private Light light;

	void Start () {
        light = GetComponentInChildren<Light>();
	}
	
	public void ActivateLight()
    {
        light.enabled = true;
    }

    public void DesactivateLight()
    {
        light.enabled = false;
    }
}
