using UnityEngine;
using Player;

namespace Inputs
{
    public class InputComponent
    {
        public float horizontalVal { get; private set; }
        public float verticalVal { get; private set; }
        private bool shoot { get; set; }

        public PlayerController playerController { private get; set; }
        public InputComponentScriptable inputComponentScriptable { private get; set; }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(inputComponentScriptable.fireKey))
            {
                playerController.setFireState();
            }
            else if (Input.GetKeyUp(inputComponentScriptable.fireKey))
            {
                playerController.SetStateFales(playerController.characterFireState);
            }

            MoveForward();
            MoveBackward();
            TurnLeft();
            TurnRight();

            if (horizontalVal != 0 || verticalVal != 0)
            {
                playerController.setMoveState();
            }
            else if (horizontalVal == 0 && verticalVal == 0)
            {
                playerController.setIdleState();
            }
        }

        void MoveForward()
        {
            if (Input.GetKeyDown(inputComponentScriptable.forwardKey))
            {
                verticalVal = 1;
            }
            else if (Input.GetKeyUp(inputComponentScriptable.forwardKey))
                verticalVal = 0;
        }

        void MoveBackward()
        {
            if (Input.GetKeyDown(inputComponentScriptable.backwardKey))
            {
                verticalVal = -1;
            }
            else if (Input.GetKeyUp(inputComponentScriptable.backwardKey))
                verticalVal = 0;
        }

        void TurnLeft()
        {
            if (Input.GetKeyDown(inputComponentScriptable.turnLeftKey))
            {
                horizontalVal = -1;
            }
            else if (Input.GetKeyUp(inputComponentScriptable.turnLeftKey))
                horizontalVal = 0;
        }

        void TurnRight()
        {
            if (Input.GetKeyDown(inputComponentScriptable.turnRightKey))
            {
                horizontalVal = 1;
            }
            else if (Input.GetKeyUp(inputComponentScriptable.turnRightKey))
                horizontalVal = 0;
        }
    }
}