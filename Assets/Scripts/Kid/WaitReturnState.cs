using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class WaitReturnState : KidState
    {
        public WaitReturnState(KidBehaviour kid) : base("Idle", kid)
        {
            
        }
        public override void OnEnter()
        {
            base.OnEnter();
            //Kid.ChangeState(new PatrolState(Kid));
            transform.position = Kid.OriginalPosition;
            transform.rotation = Kid.OriginalRotation;
        }
        public override void OnUpdate()
        {
            base.OnUpdate();

            transform.position = Kid.OriginalPosition;
            transform.rotation = Kid.OriginalRotation;


            if (Kid.Group.State == GroupState.Patrol)
            {
                Kid.ChangeState(new PatrolState(Kid));
            }

        }
    }
}
