using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class IdleAction : InputAction
    {
        public override void Execute()
        {
            PlayerManager.Instance.playerController.setIdleState(0, 0);
        }
    }
}