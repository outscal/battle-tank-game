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

        public CharacterMoveState(PlayerController playerController)
        {
            this.playerController = playerController;
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
            playerController.MovePlayer();
        }

    }
}