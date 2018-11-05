using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTestSphere : MonoBehaviour, IInteractive
{

    public ShaderEffect shaderNiveauGris;
    public EnigmeManager enigmeManager;

    public void Interact()
    {
        this.shaderNiveauGris.enabled = false;
        this.enigmeManager.hasTheRightPerception = true;
    }
}
