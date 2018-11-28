using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : MonoBehaviour where T : struct
{
    [HideInInspector]
    public T currentState;
    [HideInInspector]
    public T previousState;

    protected State currentStateReference;
    protected Dictionary<T, State> stateList;

    protected virtual void Start()
    {
        currentStateReference = new State(gameObject);
        stateList = new Dictionary<T, State>();
    }

    public void AddState(T stateEnum, State StateInstance)
    {
        if (StateInstance != null)
            stateList.Add(stateEnum, StateInstance);
    }

    public virtual void ChangeState(T newState)
    {
        if (currentStateReference != null)
            currentStateReference.Exit();

        currentStateReference = stateList[newState];
        previousState = currentState;
        currentState = newState;

        currentStateReference.Enter();
    }

    private void Update()
    {
        if (currentStateReference != null)
            currentStateReference.Execute();

        HandleLogic();
    }

    protected virtual void HandleLogic()
    {

    }
}