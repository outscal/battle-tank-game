using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AchievementM;
using BTScriptableObject;
using UI;
using Common;
using System;
using UnityEngine.UI;

namespace Reward
{
    public class RewardManager : Singleton<RewardManager>
    {
        public event Action<GameObject> RewardButtonClicked;

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private RewardScriptableObject rewardScriptableObject;

        private List<RewardInfo> rewardList;

        public List<RewardInfo> RewardList { get { return rewardList; } }

        private List<RewardButton> rewardButtons;
        string rewardInfo;

        RectTransform unlockScroll;
        bool initialized = false;

        // Use this for initialization
        public void PopulateRewardButtons(RectTransform unlockScroll)
        {
            this.unlockScroll = unlockScroll;
            rewardButtons = new List<RewardButton>();

            rewardList = new List<RewardInfo>();
            if (rewardScriptableObject.rewardsList.Count > 0)
            {
                for (int i = 0; i < rewardScriptableObject.rewardsList.Count; i++)
                {
                    rewardList.Add(rewardScriptableObject.rewardsList[i]);
                }

                SpawnButtons();
            }
        }

        void SpawnButtons()
        {
            unlockScroll.sizeDelta = new Vector2((unlockScroll.sizeDelta.x + 10) * rewardList.Count,
                                                          unlockScroll.sizeDelta.y);

            for (int i = 0; i < rewardList.Count; i++)
            {
                GameObject rewardButton = Instantiate(buttonPrefab);
                rewardButton.name += "_" + i;

                if (AchivementListCountCheckWithRewardList(i))
                {
                    rewardInfo = "Unlock AT " + AchievementManager.Instance.GetAchievementName(rewardList[i].achievementIndex) + " " +
                                                 AchievementManager.Instance.GetAchievementThreshHolder(rewardList[i].achievementIndex);
                    rewardButton.GetComponent<RewardButton>().rewardIndex = i;
                }
                else
                {
                    Debug.Log("[RewardManager] Error with Achievements Data");
                }


                rewardButton.transform.SetParent(unlockScroll);
                rewardButtons.Add(rewardButton.GetComponent<RewardButton>());
                rewardButtons[i].infoText.text = rewardInfo;
                rewardButtons[i].button.interactable = false;
                if (RewardBtnInteractableIfAchievementUnlocked(i))
                {
                    rewardButtons[i].infoText.text = "Unlocked";
                    rewardButtons[i].button.interactable = true;
                }
            }
        }

        void UpdateRewardButtons()
        {
            if(rewardButtons.Count >= rewardList.Count)
            {
                for (int i = 0; i < rewardList.Count; i++)
                {
                    rewardButtons[i].infoText.text = rewardInfo;
                    rewardButtons[i].button.interactable = false;
                    if (RewardBtnInteractableIfAchievementUnlocked(i))
                    {
                        rewardButtons[i].infoText.text = "Unlocked";
                        rewardButtons[i].button.interactable = true;
                    }
                }
            }
        }

        private bool RewardBtnInteractableIfAchievementUnlocked(int i)
        {
            return AchievementManager.Instance.AchievementList[rewardList[i].achievementIndex].achievementInfo.achievementStatus == AchievementStatus.Unlocked;
        }

        private bool AchivementListCountCheckWithRewardList(int i)
        {
            return AchievementManager.Instance.AchievementList.Count >= rewardList[i].achievementIndex;
        }

        public void RewardButtonMth(int rewardIndex)
        {
            Debug.Log("Reward Button CLicked Index:" + rewardIndex);
            RewardButtonClicked?.Invoke(rewardList[rewardIndex].rewardPrefab);
        }
    }
}