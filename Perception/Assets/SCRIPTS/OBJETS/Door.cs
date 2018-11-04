using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private Animator animator;
    private Collider collid;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        collid = GetComponent<Collider>();
	}
	
	public void OpenDoor()
    {
        animator.SetBool("isOpen", true);
        collid.enabled = false;
    }

    public void CloseDoor()
    {
        animator.SetBool("isOpen", false);
        collid.enabled = true;
    }
}
