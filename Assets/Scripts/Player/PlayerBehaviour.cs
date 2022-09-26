using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : StateMachineBase
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotateSpeed;

    public float MoveSpeed { get { return _moveSpeed; } }
    public float RotateSpeed { get { return _rotateSpeed; } }

    public AttackController AttackController { get; private set; }

    private void Awake()
    {
        AttackController = GetComponent<AttackController>();
    }
    public Vector3 GetInputVector()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        return new Vector3(hor, 0, ver).normalized;
    }
    protected override StateBase GetInitialState()
    {
        return new PlayerStates.IdleState(this);
    }
}
