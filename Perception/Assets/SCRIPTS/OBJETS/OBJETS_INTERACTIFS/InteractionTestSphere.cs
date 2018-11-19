using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTestSphere : MonoBehaviour, IInteractive
{
    public VisionStates vision;

    public void Interact()
    {
        Debug.Log("ddddddddddddddd");
        VisionStateMachine.Instance.ChangeState(vision);       
    }

    public bool IsActive()
    {
        return true;
    }
}
