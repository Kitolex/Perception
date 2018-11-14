using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTestSphere : MonoBehaviour, IInteractive
{

    public EnigmeManager enigmeManager;

    public void Interact()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<VisionStateMachine>().ChangeState(VisionStates.ChromaVision);
        this.enigmeManager.hasTheRightPerception = true;
    }
}
