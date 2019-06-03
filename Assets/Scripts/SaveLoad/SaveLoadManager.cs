using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using AchievementM;
using BTScriptableObject;
using System;

namespace SaveLoad
{
    public class SaveLoadManager : Singleton<SaveLoadManager>
    {
        public event Action<AchievementType, int> AchievementUnlocked;

        private void Start()
        {
            AchievementManager.Instance.AchievementCheck += LoadAchievement;
        }

        void SaveAchievement(AchievementType achievementType, int achievementIndex)
        {
            PlayerPrefs.SetInt(achievementType.ToString() + "_" + achievementIndex.ToString(), 1);
            //Debug.Log(achievementType.ToString() + "_" + achievementIndex.ToString() + " achievement Unlocked");
            AchievementUnlocked?.Invoke(achievementType, achievementIndex);
        }

        void LoadAchievement(AchievementType achievementType, int achievementIndex)
        {
            if(PlayerPrefs.HasKey(achievementType.ToString() + "_" + achievementIndex.ToString()))
            {
                if(PlayerPrefs.GetInt(achievementType.ToString() + "_" + achievementIndex.ToString()) == 1)
                {
                    //Debug.Log(achievementType.ToString() + "_" + achievementIndex.ToString() + " already Unlocked");
                }
                else
                    SaveAchievement(achievementType, achievementIndex);
            }
            else
            {
                Debug.Log("[SaveLoadManager] Saving Data");
                SaveAchievement(achievementType, achievementIndex);
            }
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.Save();
        }

    }
}