using System.Collections.Generic;
using Common;
using UnityEngine;
using Manager;
using Player;
using StateMachine;
using UnityEngine.SceneManagement;
using Replay;
using Interfaces;

namespace InputControls
{
    public class InputManager : IInput
    {
        private List<InputComponent> inputComponentList = new List<InputComponent>();

        private IGameManager gameManager;

        public InputManager()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            //Debug.Log("[InputManager]" + gameManager);
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
                        StartService.Instance.GetService<IReplay>().SaveCurrentQueueData(actions, _playerController.playerID, gameManager.GetGamesFrame());

                    if (StartService.Instance.GetService<IReplay>().GetSavedQueueData().Count > 0)
                    {
                        QueueData currentFrameData;// = new QueueData();
                        currentFrameData = StartService.Instance.GetService<IReplay>().GetSavedQueueData().Dequeue();

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
                if (StartService.Instance.GetService<IReplay>().GetReplayQueueData().Count > 0)
                {
                    //Debug.Log("[InputManager] Frame rate: " + (GameManager.Instance.GamePlayFrames) + "/" + ReplayManager.Instance.replayQueue.Peek().frameNo);
                    if (StartService.Instance.GetService<IReplay>().GetReplayQueueData().Peek().frameNo == gameManager.GetGamesFrame())
                    {
                        //QueueData currentFrameData;
                        //currentFrameData = ReplayManager.Instance.replayQueue.Dequeue();
                        //List<PlayerQueueData> playerQueueDatas = currentFrameData.playerQueueDatas;

                        foreach (PlayerController _playerController in PlayerManager.Instance.playerControllerList)
                        {

                            QueueData currentFrameData;
                            currentFrameData = StartService.Instance.GetService<IReplay>().GetReplayQueueData().Dequeue();

                            //Debug.Log("[InputManager] Data Frame:" + currentFrameData.frameNo +
                                      //" Game Frame " + gameManager.GetGamesFrame());
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
                        //Debug.Log("[InputManager] Data Frame:" + replayManager.GetReplayQueueData().Peek().frameNo +
                                  //" Game Frame " + gameManager.GetGamesFrame());
                    }
                }

                if (StartService.Instance.GetService<IReplay>().GetReplayQueueData().Count <= 0)
                {
                    gameManager.OnGameOver();
                    gameManager.UpdateGameState(new GameOverState());
                    SceneManager.LoadScene(gameManager.GetDefaultScriptable().gameOverScene);
                }
            }

        }

        public  void AddInputComponent(InputComponent inputComponent)
        {
            inputComponentList.Add(inputComponent);
            //Debug.Log("[InputManager] InputAdded");
        }

        public void RemoveInputComponent(InputComponent inputComponent)
        {
            for (int i = 0; i < inputComponentList.Count; i++)
            {
                if (inputComponentList[i] == inputComponent)
                {
                    inputComponentList.RemoveAt(i);
                    //Debug.Log("[InputManager] Remove InputComponent at index " + i);
                }
            }
        }

        void OnGameStart()
        {
            StartService.Instance.GetService<IReplay>().SetReplayQueueData(new Queue<QueueData>());
            StartService.Instance.GetService<IReplay>().SetSavedQueueData(new Queue<QueueData>());
        }

        public void EmptyInputComponentList()
        {
            inputComponentList.Clear();
        }
    }
}