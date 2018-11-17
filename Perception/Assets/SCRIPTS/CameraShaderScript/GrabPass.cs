using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GrabPass : MonoBehaviour {
	public float Distortion = 130f;


	// Use this for initialization
	void Start () {
		if (GetComponent<Image> ().material != null) {
			GetComponent<Image> ().material = new Material (Shader.Find ("GrabPassBlur"));
		}
		GetComponent<Image> ().material.SetFloat("_Size", Distortion);

	}

	void Update(){
		GetComponent<Image> ().material.SetFloat("_Size", Distortion);
	}

}