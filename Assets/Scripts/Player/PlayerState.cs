using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : StateBase
{
    public PlayerBehaviour Player { get; private set; }
    protected Transform transform { get { return Player.transform; } }
    public PlayerState(string name, PlayerBehaviour player) : base(name, player)
    {
        Player = player;
    }
}
