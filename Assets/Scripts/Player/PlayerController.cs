using System;
using UnityEngine;
using Bullet;
using Inputs;
using UI;
using StateMachine;
using System.Collections.Generic;
using BTManager;

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        public InputComponent playerInput { get; private set; }

        public event Action<int> scoreUpdate;
        public event Action<int> healthUpdate;

        public CharacterState currentState { get; private set; }
        public CharacterIdleState characterIdleState { get; private set; }
        public CharacterMoveState characterMoveState { get; private set; }
        public CharacterFireState characterFireState { get; private set; }
        public CharacterTakeDamageState characterTakeDamageState { get; private set; }

        public bool isDead { get; private set; }
        private int deathCount = 0;
        private float deathTime = 0;

        public float horizontalVal, verticalVal;

        public Dictionary<CharacterState, bool> playerStates;
        GameObject prefab;

        public PlayerController(InputComponentScriptable inputComponentScriptable, Vector3 position, GameObject tankPrefab)
        {
            playerStates = new Dictionary<CharacterState, bool>();
            characterIdleState = new CharacterIdleState();
            characterIdleState.OnStateEnter();
            playerStates.Add(characterIdleState, true);

            if (tankPrefab == null)
                prefab = Resources.Load<GameObject>("Tank");
            else
                prefab = tankPrefab;

            GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);
            tankObj.transform.position = position;

            playerModel = new PlayerModel();
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this);
            //List<InputAction> actions = new List<InputAction>();
            //actions.Add(new SpawnAction(playerView.transform.position));
            playerInput = new InputComponent();
            playerInput.playerController = this;
            playerInput.inputComponentScriptable = inputComponentScriptable;
            InputManager.Instance.AddInputComponent(playerInput);
            PlayerManager.Instance.playerSpawned += InvokeEvents;

        }

        public void OnUpdate(List<InputAction> action)
        {
            if (GameManager.Instance.currentState.gameStateType == GameStateType.Pause) return;

            if (isDead == false)
            {
                if (action.Count > 0)
                {
                    for (int i = 0; i < action.Count; i++)
                    {
                        action[i].Execute();
                    }
                }
            }
            else
            {
                Death();
            }
        }

        private void InvokeEvents()
        {
            healthUpdate?.Invoke(playerModel.Health);
            scoreUpdate?.Invoke(playerModel.score);
        }

        public void DestroyPlayer()
        {
            PlayerManager.Instance.playerSpawned -= InvokeEvents;
            //GameUI.InstanceClass.Respawn(playerInput);
            GameManager.Instance.UpdateGameState(new GameOverState());

            playerModel = null;
        }

        void Death()
        {
            if ((Time.time - deathTime) > 2f)
            {
                isDead = false;
                playerView.gameObject.SetActive(true);
                PlayerManager.Instance.GetSafePosition();
                //List<InputAction> actions = new List<InputAction>();
                //actions.Add(new SpawnAction(PlayerManager.Instance.safePos));
                //playerView.transform.position = PlayerManager.Instance.safePos;
                playerModel.Health = 5;
                healthUpdate?.Invoke(playerModel.Health);
                setPlayerHealth(playerModel.Health);
            }
        }

        public void TakeDamage(int value)
        {
            playerModel.Health -= value;
            healthUpdate?.Invoke(playerModel.Health);
            setPlayerHealth(playerModel.Health);

            if (playerModel.Health <= 0)
            {
                deathCount++;
                //if (deathCount < 5)
                //{
                //    deathTime = Time.time;
                //    isDead = true;
                //    playerView.gameObject.SetActive(false);
                //    List<InputAction> actions = new List<InputAction>();
                //    actions.Add(new DeathAction());
                //    InputManager.Instance.SaveCurrentQueueData(actions);
                //}
                //else
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

        public void setIdleState(float hVal, float vVal)
        {
            horizontalVal = hVal;
            verticalVal = vVal;
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
                currentState = characterIdleState;
                characterIdleState.OnStateEnter();

                if (characterMoveState != null)
                {
                    SetStateFales(characterMoveState);
                }
            }
        }

        public void setMoveState(float hVal, float vVal)
        {
            horizontalVal = hVal;
            verticalVal = vVal;

            if (characterMoveState == null)
            {
                characterMoveState = new CharacterMoveState(this);
                currentState = characterMoveState;
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
                currentState = characterFireState;
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

        public Vector3 getSpawnPos()
        {
            return playerView.transform.position;
        }

        public void setSpawnPos(Vector3 pos)
        {
            playerView.transform.position = pos;
        }

        public void SetStateFales(CharacterState characterState)
        {
            playerStates[characterState] = false;
            characterState.OnStateExit();

            if(!playerStates.ContainsValue(true))
            {
                setIdleState(0, 0);
            }
        }

    }
}