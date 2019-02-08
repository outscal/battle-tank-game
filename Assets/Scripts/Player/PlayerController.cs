using System;
using UnityEngine;
using Bullet;
using Inputs;
using UI;
using StateMachine;
using System.Collections.Generic;

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        public InputComponent playerInput { get; private set; }

        public event Action<int> scoreUpdate;
        public event Action<int> healthUpdate;

        public CharacterIdleState characterIdleState { get; private set; }
        public CharacterMoveState characterMoveState { get; private set; }
        public CharacterFireState characterFireState { get; private set; }
        public CharacterTakeDamageState characterTakeDamageState { get; private set; }

        public Dictionary<CharacterState, bool> playerStates;

        public PlayerController(InputComponentScriptable inputComponentScriptable, Vector3 position)
        {
            playerStates = new Dictionary<CharacterState, bool>();
            characterIdleState = new CharacterIdleState();
            characterIdleState.OnStateEnter();
            playerStates.Add(characterIdleState, true);

            GameObject prefab = Resources.Load<GameObject>("Tank");
            GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);
            tankObj.transform.position = position;

            playerModel = new PlayerModel();
            playerInput = new InputComponent();
            playerInput.playerController = this;
            playerInput.inputComponentScriptable = inputComponentScriptable;
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this);
            InputManager.Instance.AddInputComponent(playerInput);
            PlayerManager.Instance.playerSpawned += InvokeEvents;

        }

        private void InvokeEvents()
        {
            healthUpdate?.Invoke(playerModel.Health);
            scoreUpdate?.Invoke(playerModel.score);
        }

        public void DestroyPlayer()
        {
            PlayerManager.Instance.playerSpawned -= InvokeEvents;
            GameUI.InstanceClass.Respawn(playerInput);
            playerModel = null;
        }

        public void TakeDamage(int value)
        {
            playerModel.Health -= value;
            healthUpdate?.Invoke(playerModel.Health);
            setPlayerHealth(playerModel.Health);

            if (playerModel.Health <= 0)
            {
                playerView.PlayerDie();
            }
        }

        public void setPlayerScore(int value)
        {
            playerModel.score += value;
            scoreUpdate?.Invoke(playerModel.score);
        }

        void setPlayerHealth(int value)
        {
            playerModel.Health = value;
        }

        public void setIdleState()
        {
            if (characterIdleState == null)
            {
                characterIdleState = new CharacterIdleState();
                playerStates.Add(characterIdleState, true);
                characterIdleState.OnStateEnter();

                if (characterMoveState != null)
                    SetStateFales(characterMoveState);
            }

            bool value;

            playerStates.TryGetValue(characterIdleState, out value);

            if (value == false)
            {
                playerStates[characterIdleState] = true;
                characterIdleState.OnStateEnter();

                if (characterMoveState != null)
                    SetStateFales(characterMoveState);
            }
        }

        public void setMoveState()
        {
            if (characterMoveState == null)
            {
                characterMoveState = new CharacterMoveState(this);
                playerStates.Add(characterMoveState, true);
                characterMoveState.OnStateEnter();
                if (characterIdleState != null)
                    SetStateFales(characterIdleState);
            }

            bool value;

            playerStates.TryGetValue(characterMoveState, out value);

            if (value == false)
            {
                playerStates[characterMoveState] = true;
                characterMoveState.OnStateEnter();

                if (characterIdleState != null)
                    SetStateFales(characterIdleState);
            }
        }

        public void setFireState()
        {
            if (characterFireState == null)
            {
                characterFireState = new CharacterFireState(this);
                playerStates.Add(characterFireState, true);
                characterFireState.OnStateEnter();
            }

            bool value;

            playerStates.TryGetValue(characterFireState, out value);

            if (value == false)
            {
                playerStates[characterFireState] = true;
                characterFireState.OnStateEnter();
            }
        }

        public void setTakeDamageState()
        {
            if (characterTakeDamageState == null)
            {
                characterTakeDamageState = new CharacterTakeDamageState(this);
                playerStates.Add(characterTakeDamageState, true);
                characterTakeDamageState.OnStateEnter();
            }

            bool value;

            playerStates.TryGetValue(characterTakeDamageState, out value);

            if (value == false)
            {
                playerStates[characterTakeDamageState] = true;
                characterTakeDamageState.OnStateEnter();
            }
        }

        public void SetStateFales(CharacterState characterState)
        {
            playerStates[characterState] = false;
            characterState.OnStateExit();

            if(!playerStates.ContainsValue(true))
            {
                setIdleState();
            }
        }

    }
}