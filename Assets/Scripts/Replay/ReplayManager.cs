using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Inputs;
using BTManager;

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

        [HideInInspector]
        public int initialFrame, replayFrame;

        protected override void Awake()
        {
            base.Awake();
            initialFrame = Time.frameCount;
            replayQueue = new Queue<QueueData>();
            savedQueueData = new Queue<QueueData>();
        }

        private void Start()
        {
            GameManager.Instance.ReplayGame += ReplayGame;
        }

        void ReplayGame()
        {
            replayFrame = Time.frameCount;
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