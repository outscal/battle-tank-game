using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class InputComponent
    {
        public float horizontalVal { get; private set; }
        public float verticalVal { get; private set; }
        public bool shoot { get; private set; }

        private PlayerController playerController;
        private InputComponentScriptable inputComponentScriptable;

        public PlayerController GetController()
        {
            return playerController;
        }

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public void SetInputComponentValues(InputComponentScriptable inputComponentScriptable)
        {
            this.inputComponentScriptable = inputComponentScriptable;
        }

        public void OnUpdate()
        {
            MoveForward();
            MoveBackward();
            TurnLeft();
            TurnRight();

            if (Input.GetKeyDown(inputComponentScriptable.fireKey))
            {
                shoot = true;
            }

            if(Input.GetKeyUp(inputComponentScriptable.fireKey))
            {
                shoot = false;
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