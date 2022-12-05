using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KidBehaviour : StateMachineBase
{
    PlayerBehaviour _player;
    [SerializeField] float _followDuration;
    [SerializeField] GameObject _hitEffectPrefab;

    public KidGroup Group;

    public float FollowDuration { get { return _followDuration; } }

    bool IsGameOver { get { return CurrentState is KidStates.LoseState || CurrentState is KidStates.WinState; } }

    public Vector3 OriginalPosition { get; private set; }
    public Quaternion OriginalRotation { get; private set; }
    public PlayerBehaviour Player
    {
        get
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
            return _player;
        }
    }
    private void Update()
    {
        base.Update();
        if (Group.State == GroupState.Follow &&
                !(CurrentState is KidStates.FollowState || CurrentState is KidStates.StunnedState) &&
                !IsGameOver)
            ChangeState(new KidStates.FollowState(this));
    }
    public void AlertByMate()
    {
        ChangeState(new KidStates.FollowState(this));
    }
    public void OnGetHitted(float stunDuration)
    {
        if (CurrentState.GetType() != typeof(KidStates.LoseState) ||
            CurrentState.GetType() != typeof(KidStates.WinState))
            ChangeState(new KidStates.StunnedState(this, stunDuration));
    }
    private void Awake()
    {
        OriginalPosition = transform.position;
        OriginalRotation = transform.rotation;
    }

    protected override StateBase GetInitialState()
    {
        return new KidStates.IdleState(this);
    }

    private void OnCollisionEnter(Collision collision)
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
