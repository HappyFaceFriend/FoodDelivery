using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class StunnedState : KidState
    {
        float _duration;
        float _eTime = 0f;
        public StunnedState(KidBehaviour kid, float duration) : base("Stunned", kid)
        {
            _duration = duration;
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
    }
}
