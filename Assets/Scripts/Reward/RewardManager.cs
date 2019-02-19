using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AchievementM;
using BTScriptableObject;
using UI;
using Common;
using System;
using UnityEngine.UI;
using SaveLoad;
using Interfaces;

namespace Reward
{
    public class RewardManager : IReward
    {
        public event Action<GameObject> RewardButtonClicked;
        public event Action<int, int> RewardUnlocked;

        [SerializeField]
        private RewardScriptableObject rewardScriptableObject;

        private List<RewardInfo> rewardList;

        public List<RewardInfo> RewardList { get { return rewardList; } }

        bool initialized = false;
        private IAchievement achievementManager;

        public void RewardInitialization(int playerID)
        {
            if (rewardScriptableObject == null)
                rewardScriptableObject = Resources.Load<RewardScriptableObject>("RewardList");

            if (initialized == false)
            {
                if (achievementManager == null)
                    achievementManager = StartService.Instance.GetService<IAchievement>();
                achievementManager.AchievementCheck += UnlockedReward;
                initialized = true;

                rewardList = new List<RewardInfo>();
                if (rewardScriptableObject.rewardsList.Count > 0)
                {
                    for (int i = 0; i < rewardScriptableObject.rewardsList.Count; i++)
                    {
                        RewardInfo rewardInfo = new RewardInfo();
                        rewardInfo = rewardScriptableObject.rewardsList[i];
                        bool unlocked = SaveLoadManager.Instance.GetRewardProgress(i, playerID);
                        if (unlocked == true)
                            rewardInfo.rewardStatus = RewardStatus.Unlocked;
                        rewardList.Add(rewardInfo);
                    }
                }
            }
        }

        void UnlockedReward(int rewardIndex, int playerID)
        {
            if (rewardList.Count >= rewardIndex)
            {
                RewardInfo rewardInfo = new RewardInfo();
                rewardInfo = rewardList[rewardIndex];
                rewardInfo.rewardStatus = RewardStatus.Unlocked;
                rewardList[rewardIndex] = rewardInfo;
                RewardUnlocked?.Invoke(rewardIndex, playerID);
            }
        }

        public void OnUpdate()
        {

        }
    }
}