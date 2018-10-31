using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour {

    public float InteractRange = 2f;  // Distance max d'interaction

    private Camera cam;

    private bool alreadyHovering;

	void Start () {
        cam = Camera.main;
        alreadyHovering = false;
    }
	

	void Update () {
        HandleInput();
        if (IsHovering()) {
            if(!alreadyHovering) {
                SoundManager.Instance.StartHoverSong();
                alreadyHovering = true;
            }
        } else if (alreadyHovering) {
            SoundManager.Instance.StopHoverSong();
            alreadyHovering = false;
        }
	}

    void HandleInput()
    {
        if (Input.GetButtonDown("Interact"))
            CheckForCollision();
    }

    // Renvoie vrai si le joueur oeut intéragir avec un objet
    bool IsHovering()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        return Physics.Raycast(ray, InteractRange, LayerMask.GetMask("Interactive"));
    }

    // Déclenche une interaction
    void CheckForCollision()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, InteractRange, LayerMask.GetMask("Interactive")))
        {
            IInteractive inter = hit.collider.GetComponent<IInteractive>();
            if (inter != null)
                inter.Interact();
        }           
    }
}
