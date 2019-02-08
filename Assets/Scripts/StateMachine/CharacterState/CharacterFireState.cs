using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace StateMachine
{
    public class CharacterFireState : CharacterState
    {
        private PlayerController playerController;

        public CharacterFireState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void OnStateEnter()
        {
            Debug.Log("[CharacterFireState] FireState: OnStart");
        }

        public override void OnStateExit()
        {
            Debug.Log("[CharacterFireState] FireState: OnExit");
        }

        public override void OnUpdate()
        {
            playerController.SpawnBullet();
        }

    }
}