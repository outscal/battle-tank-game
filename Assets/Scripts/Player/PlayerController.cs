using System;
using UnityEngine;
using Bullet;
using Inputs;
using UI;
using StateMachine;
using System.Collections.Generic;
using Manager;

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        public InputComponent playerInput { get; private set; }

        public event Action<PlayerData> playerDataEvent;

        public CharacterState currentState { get; private set; }
        public CharacterIdleState characterIdleState { get; private set; }
        public CharacterMoveState characterMoveState { get; private set; }
        public CharacterFireState characterFireState { get; private set; }
        public CharacterTakeDamageState characterTakeDamageState { get; private set; }

        public int playerID { get; private set; }
        public bool isDead { get; private set; }
        private int deathCount = 0;
        private float deathTime = 0;

        public float horizontalVal, verticalVal;
        PlayerData playerData;

        public Dictionary<CharacterState, bool> playerStates;
        GameObject prefab;

        public PlayerController(InputComponentScriptable inputComponentScriptable, Vector3 position, GameObject tankPrefab, int _playerID)
        {
            playerData = new PlayerData();
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
            this.playerID = _playerID;
            playerData.playerID = _playerID;
            playerModel = new PlayerModel();
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this);

            playerInput = new InputComponent();
            playerInput.playerController = this;
            playerInput.inputComponentScriptable = inputComponentScriptable;
            InputManager.Instance.AddInputComponent(playerInput);
            GameUI.InstanceClass.SetUpUI(PlayerManager.Instance.TotalPlayer, playerID, playerView);
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
                        action[i].Execute(this);
                    }
                }
            }
            else
            {
                Death();
            }
        }

        public void SendPlayerData()
        {
            playerData.playerScore = playerModel.score;
            playerData.playerHealth = playerModel.Health;
            playerDataEvent?.Invoke(playerData);
        }

        public void DestroyPlayer()
        {
            playerModel = null;
        }

        void Death()
        {
            if ((Time.time - deathTime) > 2f)
            {
                isDead = false;
                playerView.gameObject.SetActive(true);
                PlayerManager.Instance.GetSafePosition();
                playerModel.Health = 5;
                setPlayerHealth(playerModel.Health);
            }
        }

        public void TakeDamage(int value)
        {
            playerModel.Health -= value;
            if (playerModel.Health < 0)
                playerModel.Health = 0;
                
            setPlayerHealth(playerModel.Health);

            if (playerModel.Health <= 0)
            {
                playerView.PlayerDie();
            }
        }

        public void setPlayerScore(int value)
        {
            playerModel.score += value;
            SendPlayerData();
        }

        void setPlayerHealth(int value)
        {
            playerModel.Health = value;
            SendPlayerData();
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