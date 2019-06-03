using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace StateMachine
{
    public class CharacterTakeDamageState : CharacterState
    {
        PlayerController playerController;

        public CharacterTakeDamageState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void OnStateEnter()
        {
            Debug.Log("[CharacterDamageState] DamageState: OnStart");
            playerController.TakeDamage(2);

            playerController.SetStateFales(playerController.characterTakeDamageState);
        }

        public override void OnStateExit()
        {
            Debug.Log("[CharacterDamageState] DamageState: OnExit");
        }

        public override void OnUpdate()
        {

        }

    }
}