using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates
{
    public class LoseState : PlayerState
    {
        public LoseState(PlayerBehaviour player) : base("Lose", player)
        {
        }
    }
}
