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
                playerController.playerView.MoveTank(playerInput.horizontalVal, playerInput.verticalVal,
                                                     playerModel.Speed, playerModel.RotationSpeed);
            }
        }

    }
}