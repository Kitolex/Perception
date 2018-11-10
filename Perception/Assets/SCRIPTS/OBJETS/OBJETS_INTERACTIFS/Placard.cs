using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : MonoBehaviour, IInteractive {

    private bool isOpen;

    public void Interact()
    {
        if (isOpen)
        {
            fermerPlacard();
        }
        else
        {
            ouvrirPlacard();
        }
        
    }

    // Use this for initialization
    void Start () {
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ouvrirPlacard()
    {
        isOpen = true;
        Debug.Log("ddd");
        transform.Rotate(0,90,0);
    }
    public void fermerPlacard()
    {
        isOpen = false;
        Debug.Log("ddd");
        transform.Rotate(0, -90, 0);
    }


}
