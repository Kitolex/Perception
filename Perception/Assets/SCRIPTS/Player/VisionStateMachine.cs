using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionStateMachine : StateMachine<VisionStates>{

    public static VisionStateMachine Instance;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    protected override void Start()
    {
        base.Start();

        AddState(VisionStates.BlackWhiteVision, new BlackWhiteVision(gameObject));
        AddState(VisionStates.ChromaVision, new ChromaVision(gameObject));
        AddState(VisionStates.RedVision,new RedVision(gameObject) );
        AddState(VisionStates.GreenVision,new GreenVision(gameObject) );
        AddState(VisionStates.BlueVision,new BlueVision(gameObject) );
        AddState(VisionStates.MidBlurVision,new BlurVision(gameObject) );

        ChangeState(VisionStates.BlackWhiteVision);
    }
}
