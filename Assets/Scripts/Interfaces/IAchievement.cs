using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Interfaces
{
    public interface IAchievement : IService
    {
        event Action<int, int> AchievementCheck;
        event Action<string> AchievementUnlocked;

        void AchievmentInitialize(int playerID);
    }
}
