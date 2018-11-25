using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : MonoBehaviour, IInteractive {

    private EventManager eventManager;
    public VisionStates VisionStates;

    void Start()
    {
        eventManager = GetComponent<EventManager>();
    }

    public void Interact()
    {
        VisionStateMachine.Instance.ChangeState(VisionStates);
        eventManager.activation();
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return true;
    }
}
