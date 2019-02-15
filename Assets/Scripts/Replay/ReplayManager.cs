using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Inputs;
using Manager;

namespace Replay
{
    public struct PlayerQueueData
    {
        public List<InputAction> action;
        public int playerID;
    }

    public struct QueueData
    {
        public int frameNo;
        public List<PlayerQueueData> playerQueueDatas;
        //public List<InputAction> action;
        //public int playerID;
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

        public void SaveCurrentQueueData(List<InputAction> inputActions, int playerID, int frameNo)
        {
            QueueData queueData;
            if (savedQueueData.Count > 0 && savedQueueData.Peek().frameNo == frameNo)
            {
                queueData = savedQueueData.Peek();

            }
            else
            {
                queueData = new QueueData();
                queueData.playerQueueDatas = new List<PlayerQueueData>();
                queueData.frameNo = frameNo;
                savedQueueData.Enqueue(queueData);
                replayQueue.Enqueue(queueData);
            }

            PlayerQueueData playerQueueData = new PlayerQueueData();

            playerQueueData.action = inputActions;
            playerQueueData.playerID = playerID;

            queueData.playerQueueDatas.Add(playerQueueData);
        }

    }
}