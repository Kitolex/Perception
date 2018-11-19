using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : MonoBehaviour, IInteractive {

    private EventManager eventManager;

    void Start()
    {
        eventManager = GetComponent<EventManager>();
    }

    public void Interact()
    {
        eventManager.activation();
    }

    public bool IsActive()
    {
        return true;
    }
}
