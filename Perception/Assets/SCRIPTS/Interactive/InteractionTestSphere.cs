using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTestSphere : MonoBehaviour, IInteractive
{
    public void Interact()
    {
        Debug.Log("Interacted with sphere");
    }
}
