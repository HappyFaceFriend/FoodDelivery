﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class WinState : PlayerState
    {
        public WinState(PlayerBehaviour player) : base("Win", player)
        {
            GameObject.Find("Canvas").transform.Find("GameVictoryPanel").gameObject.SetActive(true);
        }
    }
}
