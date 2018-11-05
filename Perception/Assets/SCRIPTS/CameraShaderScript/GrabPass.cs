using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GrabPass : MonoBehaviour {
	public int Distortion = 130;


	// Use this for initialization
	void Start () {
		if (GetComponent<Image> ().material != null) {
			GetComponent<Image> ().material = new Material (Shader.Find ("GrabPassBlur"));
		}
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Image> ().material.SetInt("_Size", Distortion);

	}
}