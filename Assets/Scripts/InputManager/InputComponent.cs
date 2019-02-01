using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class InputComponent
    {
        private float horizontalVal { get; set; }
        private float verticalVal { get; set; }
        private bool shoot { get; set; }

        public PlayerController playerController { private get; set; }
        public InputComponentScriptable inputComponentScriptable { private get; set; }

        public void OnUpdate()
        {
            MoveForward();
            MoveBackward();
            TurnLeft();
            TurnRight();

            if (Input.GetKeyDown(inputComponentScriptable.fireKey))
                shoot = true;
            else if(Input.GetKeyUp(inputComponentScriptable.fireKey))
                shoot = false;

            if (horizontalVal != 0 || verticalVal != 0)
                playerController.MovePlayer(horizontalVal, verticalVal);

            if (shoot == true)
            {
                playerController.SpawnBullet();
            }
        }

        void MoveForward()
        {
            if (Input.GetKeyDown(inputComponentScriptable.forwardKey))
                verticalVal = 1;
            else if (Input.GetKeyUp(inputComponentScriptable.forwardKey))
                verticalVal = 0;
        }

        void MoveBackward()
        {
            if (Input.GetKeyDown(inputComponentScriptable.backwardKey))
                verticalVal = -1;
            else if (Input.GetKeyUp(inputComponentScriptable.backwardKey))
                verticalVal = 0;
        }

        void TurnLeft()
        {
            if (Input.GetKeyDown(inputComponentScriptable.turnLeftKey))
                horizontalVal = -1;
            else if (Input.GetKeyUp(inputComponentScriptable.turnLeftKey))
                horizontalVal = 0;
        }

        void TurnRight()
        {
            if (Input.GetKeyDown(inputComponentScriptable.turnRightKey))
                horizontalVal = 1;
            else if (Input.GetKeyUp(inputComponentScriptable.turnRightKey))
                horizontalVal = 0;
        }
    }
}