using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class FireAction : InputAction
    {
        public override void Execute(PlayerController playerController)
        {
            //PlayerManager.Instance.playerControllerList[shooterID].setFireState();
            playerController.setFireState();
        }
    }
}