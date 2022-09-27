using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : StateMachineBase
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _dashSpeed;
    [SerializeField] float _rotateSpeed;
    [SerializeField] LevelManager _levelManager;

    public float MoveSpeed { get { return _moveSpeed; } }
    public float DashSpeed { get { return _dashSpeed; } }
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
        Vector3 vec =  new Vector3(hor, 0, ver);
        if (vec.sqrMagnitude > 1)
            vec.Normalize();
        return vec;
    }
    protected override StateBase GetInitialState()
    {
        return new PlayerStates.IdleState(this);
    }
    public void OnAttackedByKid(KidBehaviour attackedKid)
    {
        _levelManager.GameOver(attackedKid);
        ChangeState(new PlayerStates.LoseState(this));
    }
    public void OnGameClear()
    {
        ChangeState(new PlayerStates.WinState(this));
    }
}
