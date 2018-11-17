using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTestSphere : MonoBehaviour, IInteractive
{

    public EnigmeManager enigmeManager;
    public VisionStates vision;

    public void Interact()
    {
        VisionStateMachine.Instance.ChangeState(vision);
        this.enigmeManager.hasTheRightPerception = true;
    }

    public bool IsActive()
    {
        return true;
    }
}
