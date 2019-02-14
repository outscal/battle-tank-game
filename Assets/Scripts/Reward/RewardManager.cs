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

namespace Reward
{
    public class RewardManager : Singleton<RewardManager>
    {
        public event Action<GameObject> RewardButtonClicked;
        public event Action<int, int> RewardUnlocked;

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

        void RewardInitialization(int playerID)
        {
            if (initialized == false)
            {
                AchievementManager.Instance.AchievementCheck += UnlockedReward;
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

        // Use this for initialization
        public void PopulateRewardButtons(RectTransform unlockScroll,int playerID)
        {
            RewardInitialization(playerID);

            this.unlockScroll = unlockScroll;
            rewardButtons = new List<RewardButton>();

            if (rewardList.Count > 0)
            {
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
                if (RewardBtnInteractableIfUnlocked(i))
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
                    if (RewardBtnInteractableIfUnlocked(i))
                    {
                        rewardButtons[i].infoText.text = "Unlocked";
                        rewardButtons[i].button.interactable = true;
                    }
                }
            }
        }

        private bool RewardBtnInteractableIfUnlocked(int i)
        {
            return rewardList[i].rewardStatus == RewardStatus.Unlocked;
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