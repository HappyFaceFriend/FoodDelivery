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
            
            if (Kid.Group.State == GroupState.Patrol)
            {

                Debug.Log("To patrol from REturn! " + Kid.name);
                Kid.ChangeState(new PatrolState(Kid));
            }

        }
    }
}
