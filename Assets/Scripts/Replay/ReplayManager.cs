using System.Collections.Generic;
using UnityEngine;
using Common;
using InputControls;
using Interfaces;

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
    }

    public class ReplayManager : IReplay
    {
        private Queue<QueueData> savedQueueData;
        private Queue<QueueData> replayQueueData;

        private IGameManager gameManager;

        public ReplayManager()
        {
            replayQueueData = new Queue<QueueData>();
            savedQueueData = new Queue<QueueData>();

            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            gameManager.ReplayGame += ReplayGame;
            gameManager.GameStarted += GameStart;
        }

        void GameStart()
        {
            replayQueueData = new Queue<QueueData>();
            //Debug.LogWarning("Replay Queue Reset");
        }

        void ReplayGame()
        {
            //Debug.Log("[InputManager] Replay Queue Count:" + replayQueueData.Count);
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
                replayQueueData.Enqueue(queueData);
            }

            PlayerQueueData playerQueueData = new PlayerQueueData();

            playerQueueData.action = inputActions;
            playerQueueData.playerID = playerID;

            queueData.playerQueueDatas.Add(playerQueueData);
        }

        public void OnUpdate()
        {

        }

        public Queue<QueueData> GetSavedQueueData()
        {
            return savedQueueData;
        }

        public Queue<QueueData> GetReplayQueueData()
        {
            return replayQueueData;
        }

        public void SetSavedQueueData(Queue<QueueData> queueDatas)
        {
            savedQueueData = queueDatas;
        }

        public void SetReplayQueueData(Queue<QueueData> queueDatas)
        {
            replayQueueData = queueDatas;
        }
    }
}