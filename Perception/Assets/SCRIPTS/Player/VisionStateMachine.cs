using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionStateMachine : StateMachine<VisionStates>{


    protected override void Start()
    {
        base.Start();

        AddState(VisionStates.BlackWhiteVision, new BlackWhiteVision(gameObject));
        AddState(VisionStates.ChromaVision, new ChromaVision(gameObject));

        ChangeState(VisionStates.BlackWhiteVision);
    }
}
