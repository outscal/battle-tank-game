using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class MoveAction : InputAction
    {
        float horizontalVal, verticalVal;

        public MoveAction(float hVal,float vVal)
        {
            horizontalVal = hVal;
            verticalVal = vVal;
        }

        public override void Execute(int shooterID)
        {
            PlayerManager.Instance.playerControllerList[shooterID].setMoveState(horizontalVal, verticalVal);
        }
    }
}