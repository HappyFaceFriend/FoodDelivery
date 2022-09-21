using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    private string _name;
    public string Name { get { return _name; } }

    protected StateMachineBase _stateMachine;
    public StateBase(string name, StateMachineBase stateMachine)
    {
        _name = name;
        _stateMachine = stateMachine;
    }

    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }



}
