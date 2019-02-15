using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class IdleAction : InputAction
    {
        public override void Execute(PlayerController playerController)
        {
            playerController.setIdleState(0, 0);
        }
    }
}