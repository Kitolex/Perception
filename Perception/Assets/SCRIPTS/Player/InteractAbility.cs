using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour {

    public float InteractRange = 2f;  // Distance max d'interaction

    private Camera cam;


	void Start () {
        cam = Camera.main;
    }
	

	void Update () {
        HandleInput();
        if (IsHovering())
            SoundManager.Instance.PlayHoverSong();
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
