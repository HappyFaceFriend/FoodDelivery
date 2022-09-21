using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
}
