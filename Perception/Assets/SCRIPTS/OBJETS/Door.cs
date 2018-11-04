using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour {

    public AudioClip sound;

    private Animator animator;
    private Collider collid;
    private AudioSource audioSource;

    void Awake () {
        this.audioSource = GetComponent<AudioSource>();
        this.animator = GetComponent<Animator>();
        this.collid = GetComponent<Collider>();
    }
	
	public void OpenDoor()
    {
        audioSource.PlayOneShot(sound);
        animator.SetBool("isOpen", true);
        collid.enabled = false;
    }

    public void CloseDoor()
    {
        audioSource.PlayOneShot(sound);
        animator.SetBool("isOpen", false);
        collid.enabled = true;
    }
}
