using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class PatrolState : KidState
    {
        PatrolBase patrol;

        float _eTime = 0f;
        float _checkInterval = 0.05f;
        public PatrolState(KidBehaviour kid) : base("Patrol", kid)
        {
            patrol = kid.GetComponent<PatrolBase>();
        }
        public override void OnEnter()
        {
            base.OnEnter();
            patrol.OnEnter();
            Kid.Animator.ResetTrigger("Patrol");
            Kid.Animator.SetTrigger(patrol.GetAnimName());
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            //_movementController.MoveAndRotateTowards(nextPosition, 0.05f
            patrol.Move();
            _eTime += Time.deltaTime;
            if (_eTime >= _checkInterval)
            {
                _eTime -= _checkInterval;
                if (patrol.IsPlayerInSight())
                {
                    patrol.FollowPlayer();
                }
            }
        }
        public override void OnExit()
        {
            base.OnExit();
            patrol.OnExit();
        }
    }
}
