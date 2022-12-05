using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class StunnedState : PlayerState
    {
        Rigidbody rb;
        float duration;
        float eTime;
        public StunnedState(PlayerBehaviour player, float duration) : base("Stun", player)
        {
            this.duration = duration;
            rb = player.GetComponent<Rigidbody>();
            eTime = 0f;
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            eTime += Time.deltaTime;
            if (eTime > duration)
                Player.ChangeState(new IdleState(Player));
            rb.velocity = Vector3.zero;
        }
    }
}
