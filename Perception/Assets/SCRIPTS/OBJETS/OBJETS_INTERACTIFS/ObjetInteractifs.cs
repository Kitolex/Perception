using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetInteractifs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Méthode appelé lors de l'activation de l'objet 
     */
    public abstract void Activation();

    public virtual bool isActivable()
    {
        return true;
    }
}
