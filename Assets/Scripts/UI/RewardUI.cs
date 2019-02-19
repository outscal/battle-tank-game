using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AchievementM;
using BTScriptableObject;
using UI;
using Common;
using System;
using Reward;

public class RewardUI : Instance<RewardUI> 
{
    private RewardManager rewardManager;
    private AchievementManager achievementManager;

    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private RectTransform unlockScroll;

    public event Action<GameObject> RewardButtonClicked;
    public event Action<int, int> RewardUnlocked;

    private List<RewardButton> rewardButtons;
    string rewardInfo;

    // Use this for initialization
    public void PopulateRewardButtons(int playerID)
    {
        if (rewardManager == null)
            rewardManager = StartService.Instance.GetService<RewardManager>();
        if (achievementManager == null)
            achievementManager = StartService.Instance.GetService<AchievementManager>();

        rewardManager.RewardInitialization(playerID);

        rewardButtons = new List<RewardButton>();

        if (rewardManager.RewardList.Count > 0)
        {
            SpawnButtons();
        }
    }

    void SpawnButtons()
    {
        unlockScroll.sizeDelta = new Vector2((unlockScroll.sizeDelta.x + 10) * rewardManager.RewardList.Count,
                                                      unlockScroll.sizeDelta.y);

        for (int i = 0; i < rewardManager.RewardList.Count; i++)
        {
            GameObject rewardButton = GameObject.Instantiate(buttonPrefab);
            rewardButton.name += "_" + i;

            if (AchivementListCountCheckWithRewardList(i))
            {
                rewardInfo = "Unlock AT " + achievementManager.GetAchievementName(rewardManager.RewardList[i].achievementIndex) + " " +
                                             achievementManager.GetAchievementThreshHolder(rewardManager.RewardList[i].achievementIndex);
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
        if (rewardButtons.Count >= rewardManager.RewardList.Count)
        {
            for (int i = 0; i < rewardManager.RewardList.Count; i++)
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
        return rewardManager.RewardList[i].rewardStatus == RewardStatus.Unlocked;
    }

    private bool AchivementListCountCheckWithRewardList(int i)
    {
        return achievementManager.AchievementList.Count >= rewardManager.RewardList[i].achievementIndex;
    }

    public void RewardButtonMth(int rewardIndex)
    {
        Debug.Log("Reward Button CLicked Index:" + rewardIndex);
        RewardButtonClicked?.Invoke(rewardManager.RewardList[rewardIndex].rewardPrefab);
    }


}
