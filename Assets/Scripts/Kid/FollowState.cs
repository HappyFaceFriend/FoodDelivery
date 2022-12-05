using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class FollowState : KidState
    {
        MovementController _movementController;
        float _eTime = 0f;
        PatrolBase patrol;
        public FollowState(KidBehaviour kid) : base("Follow", kid)
        {
            _movementController = Kid.GetComponent<MovementController>();
            patrol = Kid.GetComponent<PatrolBase>();
            kid.Group.AlertAllKids(kid);
        }
        public override void OnEnter()
        {
            base.OnEnter();
            SoundManager.Instance.PlaySound(SoundManager.Instance.AlertSound, 0.35f);
            _movementController.SetSpeed(_movementController.FollowSpeed);
        }
        public override void OnExit()
        {
            base.OnExit();
            patrol.OnStopFollow();
            _movementController.SetSpeed(_movementController.MoveSpeed);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            // _movementController.MoveAndRotateTowards(Player.transform.position, 0.05f, true);
            _movementController.MoveTo(Player.transform.position);
            _eTime += Time.deltaTime;
            if (_eTime >= Kid.FollowDuration)
            {
                if(!patrol.IsPlayerInSight())
                    Kid.ChangeState(new ReturnState(Kid));
            }
        }
        
    }
}
