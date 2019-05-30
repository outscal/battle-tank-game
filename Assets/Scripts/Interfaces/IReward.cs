using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Interfaces
{
    public interface IReward : IService
    {
        event Action<GameObject> RewardButtonClicked;
        event Action<int, int> RewardUnlocked;
        void RewardInitialization(int playerID);

    }
}