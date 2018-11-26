using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : MonoBehaviour, IInteractive {

    private bool isOpen;
    public bool activable;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ouvrirPlacard()
    {
        if (activable)
        {
            isOpen = true;
            Debug.Log("ddd");
            audioSource.PlayOneShot(SoundManager.Instance.placardOpen);
            transform.Rotate(0, 90, 0);
        }

    }
    public void fermerPlacard()
    {
        if (activable)
        {
            isOpen = false;
            Debug.Log("ddd");
            audioSource.PlayOneShot(SoundManager.Instance.placardClose);            
            transform.Rotate(0, -90, 0);
        }

    }

    public bool IsActive()
    {
        return activable;
    }
}
