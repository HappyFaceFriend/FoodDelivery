using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class IdleState : KidState
    {
        public IdleState(KidBehaviour kid) : base("Idle", kid)
        {
        }
        public override void OnEnter()
        {
            base.OnEnter();
            Kid.ChangeState(new PatrolState(Kid));
        }
        public override void OnUpdate()
        {
            base.OnUpdate();

        }
    }
}
