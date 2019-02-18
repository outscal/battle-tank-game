using UnityEngine;
using Player;
using System.Collections.Generic;
using Manager;
using Replay;
using StateMachine;

namespace Inputs
{
    public class InputComponent
    {
        public float horizontalVal { get; private set; }
        public float verticalVal { get; private set; }
        private bool shoot { get; set; }

        List<InputAction> actions;
        public PlayerController playerController { get; set; }
        public InputComponentScriptable inputComponentScriptable { private get; set; }

        public List<InputAction> OnUpdate()
        {
            actions = new List<InputAction>();

            if(Input.GetKeyDown(inputComponentScriptable.fireKey))
            {
                actions.Add(new FireAction());
            }
            else if (Input.GetKeyUp(inputComponentScriptable.fireKey))
            {
                playerController.SetStateFales(playerController.characterFireState);
            }

            MoveForward();
            MoveBackward();
            TurnLeft();
            TurnRight();

            if (horizontalVal == 0 && verticalVal == 0)
            {
                if (playerController.currentState != playerController.characterIdleState)
                    actions.Add(new IdleAction());
            }

            return actions;
            //ReplayManager.Instance.SaveCurrentQueueData(actions, playerController.playerID, GameManager.Instance.GamePlayFrames);
        }

        void MoveForward()
        {
            if (Input.GetKeyDown(inputComponentScriptable.forwardKey))
            {
                verticalVal = 1;
                actions.Add(new MoveAction(playerController.horizontalVal, verticalVal));
            }
            else if (Input.GetKeyUp(inputComponentScriptable.forwardKey))
            {
                verticalVal = 0;
                actions.Add(new MoveAction(playerController.horizontalVal, verticalVal));
            }
        }

        void MoveBackward()
        {
            if (Input.GetKeyDown(inputComponentScriptable.backwardKey))
            {
                verticalVal = -1;
                actions.Add(new MoveAction(playerController.horizontalVal, verticalVal));
            }
            else if (Input.GetKeyUp(inputComponentScriptable.backwardKey))
            {
                verticalVal = 0;
                actions.Add(new MoveAction(playerController.horizontalVal, verticalVal));
            }
        }

        void TurnLeft()
        {
            if (Input.GetKeyDown(inputComponentScriptable.turnLeftKey))
            {
                horizontalVal = -1;
                actions.Add(new MoveAction(horizontalVal, playerController.verticalVal));
            }
            else if (Input.GetKeyUp(inputComponentScriptable.turnLeftKey))
            {
                horizontalVal = 0;
                actions.Add(new MoveAction(horizontalVal, playerController.verticalVal));
            }
        }

        void TurnRight()
        {
            if (Input.GetKeyDown(inputComponentScriptable.turnRightKey))
            {
                horizontalVal = 1;
                actions.Add(new MoveAction(horizontalVal, playerController.verticalVal));
            }
            else if (Input.GetKeyUp(inputComponentScriptable.turnRightKey))
            {
                horizontalVal = 0;
                actions.Add(new MoveAction(horizontalVal, playerController.verticalVal));
            }
        }
    }
}