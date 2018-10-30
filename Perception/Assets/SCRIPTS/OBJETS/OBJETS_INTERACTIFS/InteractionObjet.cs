using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //TODO : détecter interaction possible et lancer méthode objetActiver quand c'est ok
        if (Input.GetKey(KeyCode.I))
        {
            objetActiver();
        }
    }

    /**
     * Méthode qui lance la méthode activation de l'objet interractifs      
     */ 
    private void objetActiver()
    {
        ObjetInteractifs objet = GetComponent<ObjetInteractifs>();
        if (objet !=null)
        {
            objet.Activation();
        }
    }
}
