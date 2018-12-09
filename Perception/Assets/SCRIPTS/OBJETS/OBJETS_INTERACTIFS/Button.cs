using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractive
{

    private EventManager eventManager;
    public AudioClip soundOK;
    public AudioClip soundError;
    private AudioSource audioSource;

    private Light light;



    void Awake()
    {
        light = GetComponentInChildren<Light>();
        this.audioSource = GetComponent<AudioSource>();
        eventManager = GetComponent<EventManager>();
    }

 

    public void Interact()
    {
        //this.audioSource.PlayOneShot(soundOK);
        eventManager.activation();
    }

    public bool IsActive()
    {
        return true;
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
