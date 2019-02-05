using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTScriptableObject;
using System;

namespace AchievementM
{
    public class AchievementController
    {
        private Achievement achievementHolder = new Achievement();

        public Achievement AchievementHolder { get { return achievementHolder; } }

        private AchievementScriptable achievementScriptable;
        private AchievementType achievementType;

        public AchievementController(AchievementScriptable achievementScriptable, AchievementType achievementType)
        {
            this.achievementScriptable = achievementScriptable;
            this.achievementType = achievementType;
            SetAchievementData();
        }

        private void SetAchievementData()
        {
            foreach (Achievement item in achievementScriptable.achievements)
            {
                if (item.achievementType == achievementType)
                {
                    achievementHolder.AchievementName = item.AchievementName;
                    achievementHolder.achievementType = item.achievementType;
                    int r = item.achievementInfo.Count;
                    if (r > 0)
                    {
                        achievementHolder.achievementInfo = new List<AchievementInfo>();

                        for (int i = 0; i < item.achievementInfo.Count; i++)
                        {
                            achievementHolder.achievementInfo.Add(item.achievementInfo[i]);

                            //Debug.Log("[AchievementController] " + item.achievementType + " Title" +
                                      //achievementHolder.achievementInfo[i].achievementTitle + " Requirement" +
                                      //achievementHolder.achievementInfo[i].achievementRequirement);
                        }
                    }
                }
            }
        }

        public void CheckAchievement(int requiredValue)
        {
            //Debug.Log("[AchievementController] CheckAchievement");
            for (int i = 0; i < achievementHolder.achievementInfo.Count; i++)
            {
                if (requiredValue >= achievementHolder.achievementInfo[i].achievementRequirement &&
                    achievementHolder.achievementInfo[i].achievementStatus == AchievementStatus.Locked)
                    AchievementManager.Instance.CheckAchievement(achievementType, i);
            }
        }


    }

}