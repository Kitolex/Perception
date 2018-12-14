using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : MonoBehaviour, IInteractive {

    private EventManager eventManager;
    public VisionStates VisionStates;

    public string sousTitre;

    void Start()
    {
        eventManager = GetComponent<EventManager>();
    }

    public void Interact()
    {
        SoundManager.Instance.PlayOneTimeNotSpacializedSound(SoundManager.Instance.glouglou);
        VisionStateMachine.Instance.ChangeState(VisionStates);
        eventManager.activation();
        if (!sousTitre.Equals(""))
        {
            SubtitleManager.Instance.startTextsSequence(sousTitre);        
        }
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return true;
    }
}
