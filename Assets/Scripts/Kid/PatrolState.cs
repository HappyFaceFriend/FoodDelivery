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

        bool animIsIdle = false;
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
            bool doMove = true;
            if (Kid.Group.State == GroupState.Returning)
            {
                Kid.ChangeState(new ReturnState(Kid));
                return;
            }
            _eTime += Time.deltaTime;
            if (_eTime >= _checkInterval)
            {
                _eTime -= _checkInterval;
                if (patrol.IsPlayerInSight())
                {
                    if(Player.CurrentState is PlayerStates.StunnedState)
                    {
                        if(doMove)
                        {
                            doMove = false;
                            animIsIdle = true;
                            Kid.Animator.SetTrigger("Idle");
                        }

                    }
                    else
                        patrol.FollowPlayer();
                }
            }
            if(doMove)
            {
                if (animIsIdle)
                    Kid.Animator.SetTrigger(patrol.GetAnimName());
                patrol.Move();
            }
        }
        public override void OnExit()
        {
            base.OnExit();
            patrol.OnExit();
        }
    }
}
