using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : MonoBehaviour, IInteractive {

    private bool isOpen;
    public bool activable;
    public float tempsOuverture = 1.0f;

    private AudioSource audioSource;
    private Quaternion targetClose;
    private Quaternion targetOpen;
    private bool enMouvement;
    private float timer;

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
        enMouvement = false;
        audioSource = GetComponent<AudioSource>();
        targetClose = transform.rotation;
        targetOpen = Quaternion.FromToRotation(Vector3.right, Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {
		if(isOpen && enMouvement) {
            transform.rotation = Quaternion.Lerp(targetClose, targetOpen, Mathf.Clamp(Time.time - timer / tempsOuverture, 0.0f, 1.0f));
        }

        if(!isOpen && enMouvement) {
            transform.rotation = Quaternion.Lerp(targetOpen, targetClose, Mathf.Clamp(Time.time - timer / tempsOuverture, 0.0f, 1.0f));
        }

        if(enMouvement && Time.time - timer / tempsOuverture >= 1.0f) {
            enMouvement = false;
        }
	}

    public void ouvrirPlacard()
    {
        if (activable)
        {
            isOpen = true;
            Debug.Log("ddd");
            audioSource.PlayOneShot(SoundManager.Instance.placardOpen);
            enMouvement = true;
            timer = Time.time;
        } else {
            audioSource.PlayOneShot(SoundManager.Instance.placardLocked);
        }

    }
    public void fermerPlacard()
    {
        if (activable)
        {
            isOpen = false;
            Debug.Log("ddd");
            audioSource.PlayOneShot(SoundManager.Instance.placardClose);
            enMouvement = true;
            timer = Time.time;
        }

    }

    public bool IsActive()
    {
        return activable;
    }
}
