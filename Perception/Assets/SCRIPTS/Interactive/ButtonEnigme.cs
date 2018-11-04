using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnigme : MonoBehaviour, IInteractive {

    public bool IsSolution;
    [HideInInspector]
    public EnigmeManager enigmeManager; 

    public void Interact()
    {
        if (IsSolution)
            enigmeManager.SolveEnigme();
        else
            enigmeManager.ResetEnigme();
    }
}
