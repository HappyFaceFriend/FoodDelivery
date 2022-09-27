using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StateMachineBase : MonoBehaviour
{
    private StateBase _currentState;
    [SerializeField] private Animator _animator;
    public Animator Animator { get { return _animator; } }
    public StateBase CurrentState { get { return _currentState; } }
    private Dictionary<Type, Component> _cachedComponents = new Dictionary<Type, Component>();

    protected void Start()
    {
        _currentState = GetInitialState();
        if (_currentState != null)
        {
            _currentState.OnEnter();
        }
    }

    protected void Update()
    {
        if (_currentState != null)
            _currentState.OnUpdate();
    }

    public void ChangeState(StateBase newState)
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
        _animator.SetTrigger(_currentState.Name);
    }

    protected virtual StateBase GetInitialState()
    {
        return null;
    }
    public new T GetComponent<T>() where T : Component
    {
        if (_cachedComponents.ContainsKey(typeof(T)))
            return _cachedComponents[typeof(T)] as T;

        var component = base.GetComponent<T>();
        if (component != null)
            _cachedComponents.Add(typeof(T), component);
        return component;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(StateMachineBase), true)]
public class StateMachineBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        StateMachineBase stateMachine = (StateMachineBase)target;
        if (stateMachine.CurrentState == null)
            EditorGUILayout.LabelField("Current State : ", "null");
        else
            EditorGUILayout.LabelField("Current State : ", stateMachine.CurrentState.Name);
        DrawDefaultInspector();
        Repaint();
    }
}
#endif