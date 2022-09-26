using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class PatrolState : KidState
    {
        MovementController _movementController;
        public PatrolState(KidBehaviour kid) : base("Patrol", kid)
        {
            _movementController = Kid.GetComponent<MovementController>();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            Vector3 nextPosition = transform.position + transform.forward
                + transform.right * Mathf.Tan(Kid.PatrolAngle * Mathf.Deg2Rad);
                
            _movementController.MoveAndRotateTowards(nextPosition, 0.05f);
        }
    }
}
