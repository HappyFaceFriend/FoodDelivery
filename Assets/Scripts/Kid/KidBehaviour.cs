using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidBehaviour : StateMachineBase
{
    PlayerBehaviour _player;
    [SerializeField] float _patrolAngle;
    [SerializeField] float _followDuration;
    [SerializeField] GameObject _hitEffectPrefab;
    public float PatrolAngle { get{ return  _patrolAngle; } }
    public float FollowDuration { get{ return _followDuration; } }
    public PlayerBehaviour Player 
    { 
        get
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
            return _player;
        }
    }
    public void OnGetHitted(float stunDuration)
    {
        if (CurrentState.GetType() != typeof(KidStates.LoseState) ||
            CurrentState.GetType() != typeof(KidStates.WinState))
            ChangeState(new KidStates.StunnedState(this, stunDuration));
    }
    private void Awake()
    {
    }
    protected override StateBase GetInitialState()
    {
        return new KidStates.IdleState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        OnCollision(collision);
    }
    void OnCollision(Collision collision)
    {

        if (CurrentState.GetType() == typeof(KidStates.FollowState))
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector3 effectPos = (transform.position + Player.transform.position) / 2f;
                Instantiate(_hitEffectPrefab, effectPos, Quaternion.identity);
                SoundManager.Instance.PlaySound(SoundManager.Instance.HitSound);
                Player.OnAttackedByKid(this);
                ChangeState(new KidStates.WinState(this));
            }
        }
    }
    public void OnGameClear()
    {
        ChangeState(new KidStates.LoseState(this));
    }
}
