using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Inputs;
using Manager;

namespace Replay
{
    public struct QueueData
    {
        public int frameNo;
        public List<InputAction> action;
        public int playerID;
    }

    public class ReplayManager : Singleton<ReplayManager>
    {

        public Queue<QueueData> savedQueueData;
        public Queue<QueueData> replayQueue;

        protected override void Awake()
        {
            base.Awake();
            replayQueue = new Queue<QueueData>();
            savedQueueData = new Queue<QueueData>();
        }

        private void Start()
        {
            GameManager.Instance.ReplayGame += ReplayGame;
            GameManager.Instance.GameStarted += GameStart;
        }

        void GameStart()
        {
            replayQueue = new Queue<QueueData>();
            Debug.LogWarning("Replay Queue Reset");
        }

        void ReplayGame()
        {
            Debug.Log("[InputManager] Replay Queue Count:" + replayQueue.Count);
            savedQueueData = new Queue<QueueData>();
        }

        public void SaveCurrentQueueData(List<InputAction> inputActions)
        {
            QueueData queueData = new QueueData();
            queueData.frameNo = GameManager.Instance.GamePlayFrames;
            queueData.action = new List<InputAction>();
            queueData.action = inputActions;

            replayQueue.Enqueue(queueData);
            savedQueueData.Enqueue(queueData);
        }

    }
}