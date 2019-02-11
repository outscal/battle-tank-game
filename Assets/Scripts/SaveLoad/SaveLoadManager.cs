using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using AchievementM;
using BTScriptableObject;
using System;
using Reward;
using BTManager;
using Enemy;

namespace SaveLoad
{
    public enum SavedType { Achievement, Reward }
    public enum SaveMode { PlayerPrefs, JsonData, Firebase }

    public class SaveLoadManager : Singleton<SaveLoadManager>
    {
        [SerializeField]
        private SaveMode saveMode = SaveMode.PlayerPrefs;

        private ISaveLoad saveLoadController;

        protected override void Awake()
        {
            base.Awake();

            if (saveMode == SaveMode.PlayerPrefs)
            {
                saveLoadController = new PlayerPrefController();
            }
        }

        private void Start()
        {
            AchievementManager.Instance.AchievementCheck += LoadAchievement;
            RewardManager.Instance.RewardUnlocked += SaveReward;
            GameManager.Instance.GamesPlayedAdd += SaveGamesPlayedProgress;
            EnemyManager.Instance.EnemiesKillCount += SaveEnemiesKilledProgress;
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

        void SaveAchievement(int achievementIndex)
        {
            string dataString = "Achievement_" + achievementIndex.ToString();
            saveLoadController.SetBool(dataString, true);

            Debug.Log("Achievement_" + achievementIndex.ToString() + " achievement Unlocked");
        }

        void LoadAchievement(int achievementIndex)
        {
            string dataString = "Achievement_" + achievementIndex.ToString();

            bool unlocked = saveLoadController.GetBool(dataString);

            if(unlocked)
            {
                Debug.Log("Achievement_" + achievementIndex.ToString() + " already Unlocked");
            }
            else
                SaveAchievement(achievementIndex);
        }

        public bool GetAchievementProgress(string dataString, int achievementIndex)
        {
            bool unlocked = false;

            unlocked = saveLoadController.GetBool(dataString);

            return unlocked;
        }

        void SaveReward(string stringData, bool value)
        {
            saveLoadController.SetBool(stringData, value);
        }
        public bool GetRewardProgress(string dataString, int rewardIndex)
        {
            bool unlocked = false;
            return saveLoadController.GetBool(dataString);
        }

        private void OnApplicationQuit()
        {
            saveLoadController.SaveAll();
        }

    }
}