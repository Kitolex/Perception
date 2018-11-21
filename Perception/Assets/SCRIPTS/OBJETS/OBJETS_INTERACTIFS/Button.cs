using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractive
{

    private EventManager eventManager;
    public AudioClip sound;
    private AudioSource audioSource;

   

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        eventManager = GetComponent<EventManager>();
    }

 

    public void Interact()
    {
        this.audioSource.PlayOneShot(sound);
        eventManager.activation();
    }

    public bool IsActive()
    {
        return true;
    }
}
