using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace InputControls
{
    public class MoveAction : InputAction
    {
        float horizontalVal, verticalVal;

        public MoveAction(float hVal,float vVal)
        {
            horizontalVal = hVal;
            verticalVal = vVal;
        }

        public override void Execute(PlayerController playerController)
        {
            playerController.setMoveState(horizontalVal, verticalVal);
        }
    }
}