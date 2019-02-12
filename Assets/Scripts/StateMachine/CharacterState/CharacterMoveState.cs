using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Player;

namespace StateMachine
{
    public class CharacterMoveState : CharacterState
    {
        private PlayerController playerController;
        private InputComponent playerInput;
        private PlayerModel playerModel;

        public CharacterMoveState(PlayerController playerController)
        {
            this.playerController = playerController;
            playerInput = playerController.playerInput;
            playerModel = playerController.playerModel;
        }

        public override void OnStateEnter()
        {
            Debug.Log("[CharacterMoveState] MoveState: OnStart");
        }

        public override void OnStateExit()
        {
            Debug.Log("[CharacterMoveState] MoveState: OnExit");
        }

        public override void OnUpdate()
        {
            MovePlayer();
        }

        public void MovePlayer()
        {
            if (playerController.playerView != null)
            {
                Debug.Log("[CharacterMoveState] Horizontal:" + playerController.horizontalVal + " Vertical:" + playerController.verticalVal);
                playerController.playerView.MoveTank(playerController.horizontalVal, playerController.verticalVal,
                                                     playerModel.Speed, playerModel.RotationSpeed);
            }
        }

    }
}