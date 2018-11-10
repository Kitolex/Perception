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
    }

    // Use this for initialization
    void Start()
    {
        eventManager = GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        eventManager.activation();
    }
}
