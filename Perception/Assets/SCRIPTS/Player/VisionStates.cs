using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum VisionStates
{
    BlackWhiteVision,
    GreenVision,
    RedVision,
    BlueVision,
    ChromaVision,
    ThermalVision,
    NightVision
}

public class BlackWhiteVision : State
{
    public  BlackWhiteVision(GameObject target) : base(target) { }

    public override void Enter()
    {
        target.GetComponentInChildren<ShaderEffect>().enabled = true;
    }

    public override void Exit()
    {
        target.GetComponentInChildren<ShaderEffect>().enabled = false;
    }
}

public class GreenVision : State
{
    public GreenVision(GameObject target) : base(target) { }

    public override void Enter() { }
    public override void Exit() { }
}

public class RedVision : State
{
    public RedVision(GameObject target) : base(target) { }

    public override void Enter() { }
    public override void Exit() { }
}

public class BlueVision : State
{
    public BlueVision(GameObject target) : base(target) { }

    public override void Enter() { }
    public override void Exit() { }
}

public class ChromaVision : State
{
    public ChromaVision(GameObject target) : base(target) { }

    public override void Enter() { }
    public override void Exit() { }
}