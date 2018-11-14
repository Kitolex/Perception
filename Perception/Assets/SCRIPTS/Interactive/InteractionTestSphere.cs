using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTestSphere : MonoBehaviour, IInteractive
{

    public EnigmeManager enigmeManager;

    public void Interact()
    {
        VisionStateMachine.Instance.ChangeState(VisionStates.ChromaVision);
        this.enigmeManager.hasTheRightPerception = true;
    }
}
