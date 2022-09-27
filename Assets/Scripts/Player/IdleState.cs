using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class IdleState : PlayerState
    {
        public IdleState(PlayerBehaviour player) : base("Idle", player)
        {
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Player.GetInputVector().magnitude > 0)
                Player.ChangeState(new MoveState(Player));

            if (Input.GetKeyDown(KeyCode.Space) && Player.AttackController.CanAttack())
            {
                Player.AttackController.CastAttack();
            }
        }
    }
}
