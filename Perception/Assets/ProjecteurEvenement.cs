using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecteurEvenement : Evenement {

    public void flash()
    {
        
        Material mat = GetComponent<Renderer>().materials[2];
        Debug.Log(mat.name);
        mat.EnableKeyword("_EMISSION");
        VisionStateMachine.Instance.ChangeState(VisionStates.FlashVision);
        
    }

}
