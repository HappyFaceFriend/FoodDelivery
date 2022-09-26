using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] AttackHitbox _hitBox;
    [SerializeField] float _stunDuration;
    PlayerBehaviour _player;

    public float StunDuration { get { return _stunDuration; } }
    private void Awake()
    {
        _player = GetComponent<PlayerBehaviour>();
    }
    public void CastAttack()
    {
        _player.Animator.SetTrigger("Attack");
        _hitBox.gameObject.SetActive(true);
    }
}
