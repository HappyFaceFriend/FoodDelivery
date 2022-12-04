using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class ReturnState : KidState
    {
        MovementController _movementController;
        float _eTime = 0f;
        public ReturnState(KidBehaviour kid) : base("Follow", kid)
        {
            _movementController = Kid.GetComponent<MovementController>();
        }
        public override void OnEnter()
        {
            base.OnEnter();
            Kid.Group.StartReturn(Kid);
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            // _movementController.MoveAndRotateTowards(Player.transform.position, 0.05f, true);
            if(_movementController.HasArrived())
            {
                Debug.Log("Has Arived " + Kid.name);
                _movementController.StopMove();
                _movementController.RotateTowards(Kid.OriginalRotation);
                if(Quaternion.Angle(Kid.transform.rotation, Kid.OriginalRotation) < 5)
                {
                    Kid.ChangeState(new WaitReturnState(Kid));
                }
            }
            else
            {
                _movementController.MoveTo(Kid.OriginalPosition);
            }

        }
        
    }
}
