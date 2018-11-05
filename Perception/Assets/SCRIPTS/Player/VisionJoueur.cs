using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionJoueur : MonoBehaviour {

	public Transform pointVisionNette;
	public GrabPass grabPass;

	private float distanceInitiale;
	private float deformationInitiale;

	// Use this for initialization
	void Start () {
		this.distanceInitiale = Vector3.Distance(this.transform.position, pointVisionNette.position);
		this.deformationInitiale = grabPass.Distortion;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(grabPass.Distortion != 1) {
			float distanceRestanteRelative = Vector3.Distance(this.transform.position, pointVisionNette.position) / distanceInitiale;
			
			int facteurDeformation = Mathf.CeilToInt(this.deformationInitiale * distanceRestanteRelative);

			if(facteurDeformation <= 2) {
				facteurDeformation = 1;
			}

			if(grabPass.Distortion > facteurDeformation) {
				grabPass.Distortion = facteurDeformation;
			}
		}
	}
}
