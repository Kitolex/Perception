using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionEvenement : Evenement {


    public static PerceptionEvenement Instance;

    public void finFlou(){
        Debug.Log("FinFlou Debut fonction");
        VisionStateMachine.Instance.ChangeState(VisionStates.LostBlur);
    }

    



}
