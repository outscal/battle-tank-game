using System.Collections.Generic;
using Common;
using UnityEngine;
using Manager;
using Player;
using StateMachine;
using UnityEngine.SceneManagement;
using Replay;

namespace Inputs
{
    public class InputManager : Singleton<InputManager>
    {
        private List<InputComponent> inputComponentList = new List<InputComponent>();

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            GameManager.Instance.GameStarted += OnGameStart;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.currentState.gameStateType == GameStateType.Game)
            {
                foreach (PlayerController _playerController in PlayerManager.Instance.playerControllerList)
                {
                    List<InputAction> actions = _playerController.playerInput.OnUpdate();

                    if (actions.Count > 0)
                        ReplayManager.Instance.SaveCurrentQueueData(actions, _playerController.playerID, GameManager.Instance.GamePlayFrames);

                    if (ReplayManager.Instance.savedQueueData.Count > 0)
                    {
                        QueueData currentFrameData;// = new QueueData();
                        currentFrameData = ReplayManager.Instance.savedQueueData.Dequeue();

                        foreach (var playerData in currentFrameData.playerQueueDatas)
                        {
                            if (playerData.playerID == _playerController.playerID)
                                _playerController.OnUpdate(playerData.action);
                        }
                            
                    }
                }
            }
            else if (GameManager.Instance.currentState.gameStateType == GameStateType.Replay)
            {
                foreach (PlayerController _playerController in PlayerManager.Instance.playerControllerList)
                {
                    if (ReplayManager.Instance.replayQueue.Count > 0)
                    {
                        //Debug.Log("[InputManager] Frame rate: " + (GameManager.Instance.GamePlayFrames) + "/" + ReplayManager.Instance.replayQueue.Peek().frameNo);
                        if (GameManager.Instance.GamePlayFrames == ReplayManager.Instance.replayQueue.Peek().frameNo)
                        {
                            QueueData currentFrameData;// = new QueueData();
                            currentFrameData = ReplayManager.Instance.replayQueue.Dequeue();

                            Debug.Log("[InputManager] Data Frame:" + currentFrameData.frameNo +
                                      " Game Frame " + GameManager.Instance.GamePlayFrames);
                            if (currentFrameData.frameNo == GameManager.Instance.GamePlayFrames)
                            {
                                foreach (var playerData in currentFrameData.playerQueueDatas)
                                {
                                    if (playerData.playerID == _playerController.playerID)
                                        _playerController.OnUpdate(playerData.action);
                                }
                            }

                            //if (currentFrameData.playerID == PlayerManager.Instance.playerControllerList[inputComponent.playerController.playerID].playerID)
                                //PlayerManager.Instance.playerControllerList[inputComponent.playerController.playerID].OnUpdate(currentFrameData.action);
                        }
                    }
                }

                if (ReplayManager.Instance.replayQueue.Count <= 0)
                {
                    GameManager.Instance.UpdateGameState(new GameOverState());
                    SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameOverScene);
                }
            }

        }

        public  void AddInputComponent(InputComponent inputComponent)
        {
            inputComponentList.Add(inputComponent);
            Debug.Log("[InputManager] InputAdded");
        }

        public void RemoveInputComponent(InputComponent inputComponent)
        {
            for (int i = 0; i < inputComponentList.Count; i++)
            {
                if (inputComponentList[i] == inputComponent)
                {
                    inputComponentList.RemoveAt(i);
                    Debug.Log("[InputManager] Remove InputComponent at index " + i);
                }
            }
        }

        void OnGameStart()
        {
            ReplayManager.Instance.replayQueue = new Queue<QueueData>();
            ReplayManager.Instance.savedQueueData = new Queue<QueueData>();
        }

        public void EmptyInputComponentList()
        {
            inputComponentList.Clear();
        }

    }
}