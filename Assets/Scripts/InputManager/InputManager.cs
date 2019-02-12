using System.Collections.Generic;
using Common;
using UnityEngine;
using BTManager;
using Player;
using StateMachine;
using UnityEngine.SceneManagement;

namespace Inputs
{
    public struct QueueData
    {
        public int frameNo;
        public List<InputAction> action;
        public int playerID;
    }

    public class InputManager : Singleton<InputManager>
    {
        private List<InputComponent> inputComponentList = new List<InputComponent>();

        private bool onPaused = false;
        private bool gameStarted = false;
        private bool replayGame = false;

        public Queue<QueueData> savedQueueData;
        public Queue<QueueData> replayQueue;

        int initialFrame, replayFrame;

        protected override void Awake()
        {
            base.Awake();

            initialFrame = Time.frameCount;
        }

        private void Start()
        {
            replayQueue = new Queue<QueueData>();
            savedQueueData = new Queue<QueueData>();
            GameManager.Instance.GamePaused += OnPaused;
            GameManager.Instance.GameUnpaused += OnUnPaused;
            GameManager.Instance.GameStarted += OnGameStart;
            GameManager.Instance.ReplayGame += ReplayGame;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.currentState.gameStateType == GameStateType.Game)
            {
                foreach (InputComponent inputComponent in inputComponentList)
                {
                    inputComponent.OnUpdate();

                    if (savedQueueData.Count > 0)
                    {
                        QueueData currentFrameData = new QueueData();
                        currentFrameData = savedQueueData.Dequeue();
                        inputComponent.playerController.OnUpdate(currentFrameData.action);
                    }
                }
            }
            else if (GameManager.Instance.currentState.gameStateType == GameStateType.Replay)
            {
                //Debug.Log("[InputManager] Replay Mode" + replayQueue.Count);
                //Debug.Log("[InputManager] Frame rate: " + ((Time.frameCount - replayFrame) - 1) + "/" + replayQueue.Peek().frameNo);
                if (replayQueue.Count > 0)
                {
                    Debug.Log("[InputManager] Frame rate: " + ((Time.frameCount - replayFrame) - 1) + "/" + replayQueue.Peek().frameNo);
                    if ((Time.frameCount - replayFrame) - 1 == replayQueue.Peek().frameNo)
                    {
                        QueueData currentFrameData = new QueueData();
                        currentFrameData = replayQueue.Dequeue();
                        PlayerManager.Instance.playerController.OnUpdate(currentFrameData.action);
                        //Debug.Log("[InputManager] Replay Mode" +
                                  //"Action:" + replayQueue.Peek().action);
                    }
                }

                if (replayQueue.Count <= 0)
                {
                    GameManager.Instance.UpdateGameState(new GameOverState());
                    SceneManager.LoadScene(GameManager.Instance.DefaultScriptableObject.gameOverScene);
                }
            }

            if (GameManager.Instance.currentState.gameStateType == GameStateType.Pause)
            {
                replayFrame = (replayQueue.Peek().frameNo);
            }

        }

        private int CurrentFrame(int frame)
        {
            return (frame - initialFrame);
        }

        public  void AddInputComponent(InputComponent inputComponent)
        {
            inputComponentList.Add(inputComponent);
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

        void ReplayGame()
        {
            gameStarted = false;
            replayGame = true;
            replayFrame = Time.frameCount;
            Debug.Log("[InputManager] Replay Queue Count:" + replayQueue.Count);
            savedQueueData = new Queue<QueueData>();
        }

        void OnGameStart()
        {
            gameStarted = true;
            replayGame = false;
            initialFrame = Time.frameCount;
            replayQueue = new Queue<QueueData>();
            savedQueueData = new Queue<QueueData>();
        }

        void OnPaused()
        {
            onPaused = true;
        }

        void OnUnPaused()
        {
            onPaused = false;
        }

        public void EmptyInputComponentList()
        {
            inputComponentList.Clear();
        }

        public void SaveCurrentQueueData(List<InputAction> inputActions)
        {
            QueueData queueData = new QueueData();
            queueData.frameNo = CurrentFrame(Time.frameCount);
            queueData.action = new List<InputAction>();
            queueData.action = inputActions;

            replayQueue.Enqueue(queueData);
            savedQueueData.Enqueue(queueData);
        }

    }
}