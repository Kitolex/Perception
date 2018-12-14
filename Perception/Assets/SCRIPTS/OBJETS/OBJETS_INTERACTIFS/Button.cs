using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractive
{

    private EventManager eventManager;
    public AudioClip soundOK;
    public AudioClip soundError;
    public Renderer meshRendererButton;
    private AudioSource audioSource;

    private Light light;

    public bool NonEnigme;

    private bool activableNonEnigme;



    void Awake()
    {
        activableNonEnigme = true;
        light = GetComponentInChildren<Light>();
        this.audioSource = GetComponent<AudioSource>();
        eventManager = GetComponent<EventManager>();
    }

 

    public void Interact()
    {
        
        if (NonEnigme)
        {
            if (activableNonEnigme)
            {
                this.audioSource.PlayOneShot(soundOK);
                activableNonEnigme = false;
                eventManager.activation();
            }

        }
        else
        {
            eventManager.activation();
        }

        


    }

    public bool IsActive()
    {
        if (NonEnigme)
        {
            return activableNonEnigme;
        }
        GroupeBouttonEnigme gbe = GetComponentInParent<GroupeBouttonEnigme>();
        return gbe.getEnigmeActuel().getisEncours() && !gbe.finAllEnigme;
        
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
