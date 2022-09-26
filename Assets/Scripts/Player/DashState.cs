using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    public DashState(PlayerBehaviour player) : base("Dash", player)
    {
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Input.GetKeyUp(KeyCode.E))
            Player.ChangeState(new MoveState(Player));

        Vector3 moveDir = Player.GetInputVector();

        transform.Translate(moveDir * Player.MoveSpeed * Time.deltaTime * 2, Space.World);

        if (moveDir != Vector3.zero )
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Player.RotateSpeed * Time.deltaTime);
        }
        else
        {
            Player.ChangeState(new IdleState(Player));
        }
    }
}
