using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Replay;
using InputControls;

namespace Interfaces
{
    public interface IReplay : IService
    {
        Queue<QueueData> GetSavedQueueData();
        Queue<QueueData> GetReplayQueueData();


        void SetSavedQueueData(Queue<QueueData> queueDatas);
        void SetReplayQueueData(Queue<QueueData> queueDatas);

        void SaveCurrentQueueData(List<InputAction> inputActions, int playerID, int frameNo);

    }
}