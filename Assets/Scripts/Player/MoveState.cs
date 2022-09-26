﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(PlayerBehaviour player) : base("Move", player)
    {
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Input.GetKey(KeyCode.E))
            Player.ChangeState(new DashState(Player));


        Vector3 moveDir = Player.GetInputVector();

        transform.Translate(moveDir * Player.MoveSpeed * Time.deltaTime, Space.World);

        if (moveDir != Vector3.zero)
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
