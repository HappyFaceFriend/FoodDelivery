using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class FollowState : KidState
    {
        MovementController _movementController;
        float _eTime = 0f;
        public FollowState(KidBehaviour kid) : base("Follow", kid)
        {
            _movementController = Kid.GetComponent<MovementController>();
        }
        public override void OnEnter()
        {
            base.OnEnter();
            SoundManager.Instance.PlaySound(SoundManager.Instance.AlertSound, 0.35f);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            _movementController.MoveAndRotateTowards(Player.transform.position, 0.05f, true);

            _eTime += Time.deltaTime;
            if (_eTime >= Kid.FollowDuration)
            {
                Kid.ChangeState(new PatrolState(Kid));
            }
        }
        
    }
}
