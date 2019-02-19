using System.Collections.Generic;
using Common;
using UnityEngine;
using Manager;
using Player;
using StateMachine;
using UnityEngine.SceneManagement;
using Replay;
using Interfaces;

namespace Inputs
{
    public class InputManager : IInput
    {
        private List<InputComponent> inputComponentList = new List<InputComponent>();

        private IGameManager gameManager;
        private IReplay replayManager;

        public InputManager()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            if (replayManager == null)
                replayManager = StartService.Instance.GetService<IReplay>();

            Debug.Log("[InputManager]" + gameManager);
            gameManager.GameStarted += OnGameStart;
        }

        // Update is called once per frame
        public void OnUpdate()
        {
            if (gameManager.GetCurrentState().gameStateType == GameStateType.Game)
            {
                foreach (PlayerController _playerController in PlayerManager.Instance.playerControllerList)
                {
                    List<InputAction> actions = _playerController.playerInput.OnUpdate();

                    if (actions.Count > 0)
                        replayManager.SaveCurrentQueueData(actions, _playerController.playerID, gameManager.GetGamesFrame());

                    if (replayManager.GetSavedQueueData().Count > 0)
                    {
                        QueueData currentFrameData;// = new QueueData();
                        currentFrameData = replayManager.GetSavedQueueData().Dequeue();

                        foreach (var playerData in currentFrameData.playerQueueDatas)
                        {
                            if (playerData.playerID == _playerController.playerID)
                                _playerController.OnUpdate(playerData.action);
                        }

                    }
                }
            }
            else if (gameManager.GetCurrentState().gameStateType == GameStateType.Replay)
            {
                if (replayManager.GetReplayQueueData().Count > 0)
                {
                    //Debug.Log("[InputManager] Frame rate: " + (GameManager.Instance.GamePlayFrames) + "/" + ReplayManager.Instance.replayQueue.Peek().frameNo);
                    if (replayManager.GetReplayQueueData().Peek().frameNo == gameManager.GetGamesFrame())
                    {
                        //QueueData currentFrameData;
                        //currentFrameData = ReplayManager.Instance.replayQueue.Dequeue();
                        //List<PlayerQueueData> playerQueueDatas = currentFrameData.playerQueueDatas;

                        foreach (PlayerController _playerController in PlayerManager.Instance.playerControllerList)
                        {

                            QueueData currentFrameData;
                            currentFrameData = replayManager.GetReplayQueueData().Dequeue();

                            Debug.Log("[InputManager] Data Frame:" + currentFrameData.frameNo +
                                      " Game Frame " + gameManager.GetGamesFrame());
                            foreach (var playerData in currentFrameData.playerQueueDatas)
                            {
                                if (playerData.playerID == _playerController.playerID)
                                    _playerController.OnUpdate(playerData.action);
                            }

                            //if (currentFrameData.playerID == PlayerManager.Instance.playerControllerList[inputComponent.playerController.playerID].playerID)
                            //PlayerManager.Instance.playerControllerList[inputComponent.playerController.playerID].OnUpdate(currentFrameData.action);
                        }
                    }
                    else
                    {
                        Debug.Log("[InputManager] Data Frame:" + replayManager.GetReplayQueueData().Peek().frameNo +
                                  " Game Frame " + gameManager.GetGamesFrame());
                    }
                }

                if (replayManager.GetReplayQueueData().Count <= 0)
                {
                    gameManager.UpdateGameState(new GameOverState());
                    SceneManager.LoadScene(gameManager.GetDefaultScriptable().gameOverScene);
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
            replayManager.SetReplayQueueData(new Queue<QueueData>());
            replayManager.SetSavedQueueData(new Queue<QueueData>());
        }

        public void EmptyInputComponentList()
        {
            inputComponentList.Clear();
        }
    }
}