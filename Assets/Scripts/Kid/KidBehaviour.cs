using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidBehaviour : StateMachineBase
{
    PlayerBehaviour _player;
    [SerializeField] float _patrolAngle;
    public float PatrolAngle { get{ return  _patrolAngle; } }
    public PlayerBehaviour Player 
    { 
        get
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
            return _player;
        }
    }
    private void Awake()
    {
        if (Random.Range(0f, 1f) > 0.5f)
            _patrolAngle *= -1;
    }
    protected override StateBase GetInitialState()
    {
        return new KidStates.IdleState(this);
    }
}
