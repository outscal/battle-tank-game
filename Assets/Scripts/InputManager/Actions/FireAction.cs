using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class FireAction : InputAction
    {
        public override void Execute()
        {
            PlayerManager.Instance.playerController.setFireState();
            //playerController.setFireState();
        }
    }
}