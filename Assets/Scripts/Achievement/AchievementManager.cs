using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTScriptableObject;
using Common;
using System;
using UI;
using SaveLoad;
using Manager;

namespace AchievementM
{
    public class AchievementManager : Singleton<AchievementManager>
    {
        [SerializeField]
        private AchievementScriptable achievementScriptable;

        private List<Achievement> achievementList;

        public List<Achievement> AchievementList { get { return achievementList; }}

        public event Action<int, int> AchievementCheck;
        public event Action<string> AchievementUnlocked;

        bool initialized = false;

        public void AchievmentInitialize(int playerID)
        {
            if (initialized == false)
            {
                initialized = true;
                Manager.GameManager.Instance.GameStarted += InvokeDefaultEvents;
                if (achievementScriptable != null)
                {
                    achievementList = new List<Achievement>();

                    for (int i = 0; i < achievementScriptable.achievementList.Count; i++)
                    {
                        Achievement achievement = new Achievement();
                        achievement = achievementScriptable.achievementList[i];
                        bool unlocked = SaveLoadManager.Instance.GetAchievementProgress(i, playerID);
                        if (unlocked == true)
                            achievement.achievementInfo.achievementStatus = AchievementStatus.Unlocked;

                        achievementList.Add(achievement);
                    }
                }
                else
                {
                    Debug.Log("[Achievement Manager] missing scriptable object reference");
                }
            }
        }

        private void InvokeDefaultEvents()
        {
            UIManager.Instance.ScoreIncreased += ScoreIncreased;
            Enemy.EnemyManager.Instance.EnemyDestroyed += EnemyKilled;
            Manager.GameManager.Instance.GameStarted += GamesPlayed;
        }

        private void ScoreIncreased(int playerID)
        {
            CheckForAchievement(AchievementType.hiScore, UIManager.Instance.playerScore, playerID);
        }

        private void EnemyKilled(int playerID)
        {
            CheckForAchievement(AchievementType.enemyKilled, Enemy.EnemyManager.Instance.enemiesKilled, playerID);
        }

        private void GamesPlayed()
        {
            CheckForAchievement(AchievementType.gamesPlayed, Manager.GameManager.Instance.gamesPlayed, 0);
        }

        void CheckForAchievement(AchievementType achievementType, int achievedVal, int playerID)
        {
            for (int i = 0; i < achievementList.Count; i++)
            {
                if (CheckAchievementType(achievementType, i))
                {
                    if (AchievementLock(i) && AchievementThreshHold(achievedVal, i))
                    {
                        string value = "Unlocked " + achievementType.ToString() + " Achievement. Title " +
                                              achievementList[i].achievementInfo.achievementTitle;

                        Achievement achievement = new Achievement();
                        achievement = achievementList[i];
                        achievement.achievementInfo.achievementStatus = AchievementStatus.Unlocked;

                        achievementList[i] = achievement;
                        AchievementUnlocked?.Invoke(value);
                        AchievementCheck?.Invoke(i, playerID);
                    }
                }
            }
        }

        private bool CheckAchievementType(AchievementType achievementType, int i)
        {
            return achievementList[i].AchievementType == achievementType;
        }

        private bool AchievementThreshHold(int achievedVal, int i)
        {
            return achievedVal >= achievementList[i].achievementInfo.achievementRequirement;
        }

        private bool AchievementLock(int i)
        {
            return achievementList[i].achievementInfo.achievementStatus == AchievementStatus.Locked;
        }

        public string GetAchievementName(int rewardIndex)
        {
            return achievementList[rewardIndex].AchievementType.ToString();
        }

        public string GetAchievementThreshHolder(int rewardIndex)
        {
            return achievementList[rewardIndex].achievementInfo.achievementRequirement.ToString();
        }


    }
}