using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class FollowState : KidState
    {
        MovementController _movementController;
        public FollowState(KidBehaviour kid) : base("Follow", kid)
        {
            _movementController = Kid.GetComponent<MovementController>();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            _movementController.MoveAndRotateTowards(Player.transform.position, 0.05f);
        }
    }
}
