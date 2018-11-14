using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State
{
    protected GameObject target;

    public State(GameObject targetObject)
    {
        target = targetObject;
    }

    public virtual void Enter() { }
    public virtual void Execute() { }
    public virtual void Exit() { }
}
