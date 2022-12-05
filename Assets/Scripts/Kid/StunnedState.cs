using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KidStates
{
    public class StunnedState : KidState
    {
        float _duration;
        float _eTime = 0f;

        MovementController movement;
        public StunnedState(KidBehaviour kid, float duration) : base("Stunned", kid)
        {
            _duration = duration;
            movement = kid.GetComponent<MovementController>();
        }
        public override void OnEnter()
        {
            base.OnEnter();
            movement.StopMove();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            _eTime += Time.deltaTime;
            if (_eTime >= _duration)
            {
                Kid.ChangeState(new IdleState(Kid));
            }
        }
        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
