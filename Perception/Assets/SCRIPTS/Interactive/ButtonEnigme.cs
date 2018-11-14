using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonEnigme : MonoBehaviour, IInteractive {

    public bool IsSolution;
    public AudioClip sound;

    [HideInInspector]
    public EnigmeManager enigmeManager;

    private AudioSource audioSource;

    void Awake () {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        this.audioSource.PlayOneShot(sound);
        if (IsSolution)
            enigmeManager.SolveEnigme();
        else
            enigmeManager.ResetEnigme();
    }

    public bool IsActive()
    {
        return true;
    }
}
