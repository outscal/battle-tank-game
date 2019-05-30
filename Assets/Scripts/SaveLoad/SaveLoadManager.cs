using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using AchievementM;
using BTScriptableObject;
using System;
using Reward;
using Manager;
using Enemy;
using Interfaces;

namespace SaveLoad
{
    public enum SavedType { Achievement, Reward }
    public enum SaveMode { PlayerPrefs, JsonData, Firebase }

    public class SaveLoadManager : Singleton<SaveLoadManager>
    {
        [SerializeField]
        private SaveMode saveMode = SaveMode.PlayerPrefs;

        private ISaveLoad saveLoadController;
        private IAchievement achievementManager;
        private IReward rewardManager; 
        private IGameManager gameManager;
        private IEnemy enemyManager;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (saveMode == SaveMode.PlayerPrefs)
            {
                saveLoadController = new PlayerPrefController();
            }
            else if (saveMode == SaveMode.JsonData)
            {
                saveLoadController = new JsonController();
            }
        }

        public void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            if (achievementManager == null)
                achievementManager = StartService.Instance.GetService<IAchievement>();

            if (rewardManager == null)
                rewardManager = StartService.Instance.GetService<IReward>();

            if (enemyManager == null)
                enemyManager = StartService.Instance.GetService<IEnemy>();

            achievementManager.AchievementCheck += LoadAchievement;
            rewardManager.RewardUnlocked += SaveReward;
            gameManager.GamesPlayedAdd += SaveGamesPlayedProgress;
            enemyManager.EnemiesKillCount += SaveEnemiesKilledProgress;
        }

        void SaveGamesPlayedProgress(int value)
        {
            string dataString = "GamesPlayed";
            saveLoadController.SetInt(dataString, value);
        }

        public int GetGamesPlayerProgress()
        {
            return saveLoadController.GetInt("GamesPlayed");
        }

        void SaveEnemiesKilledProgress(int value)
        {
            string dataString = "EnemiesKilled";
            saveLoadController.SetInt(dataString, value);
        }

        public int GetEnemiesKilledProgress()
        {
            return saveLoadController.GetInt("EnemiesKilled");
        }

        void SaveAchievement(int achievementIndex, int playerID)
        {
            string dataString = "Achievement_" + playerID + "_" + achievementIndex.ToString();
            saveLoadController.SetBool(dataString, true);

            Debug.Log("Achievement_" + playerID + "_" + achievementIndex.ToString() + " achievement Unlocked");
        }

        void LoadAchievement(int achievementIndex, int playerID)
        {
            string dataString = "Achievement_" + playerID + "_" + achievementIndex.ToString();

            bool unlocked = saveLoadController.GetBool(dataString);

            if (unlocked)
            {
                Debug.Log("Achievement_" + playerID + "_" + achievementIndex.ToString() + " already Unlocked");
            }
            else
                SaveAchievement(achievementIndex, playerID);
        }

        public bool GetAchievementProgress(int achievementIndex, int playerID)
        {
            bool unlocked = false;
            string dataString = "Achievement_" + playerID + "_" + achievementIndex.ToString();
            unlocked = saveLoadController.GetBool(dataString);

            return unlocked;
        }

        void SaveReward(int rewardIndex, int playerID)
        {
            string dataString = "Reward_" + playerID + "_" + rewardIndex.ToString();
            saveLoadController.SetBool(dataString, true);
        }
        public bool GetRewardProgress(int rewardIndex, int playerID)
        {
            bool unlocked = false;
            string dataString = "Reward_" + playerID + "_" + rewardIndex.ToString();
            return saveLoadController.GetBool(dataString);
        }

        private void OnApplicationQuit()
        {
            saveLoadController.SaveAll();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}