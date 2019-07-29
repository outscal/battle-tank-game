using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTScriptableObject
{
    public enum RewardType { Achievement, Social, Currency }

    [CreateAssetMenu(fileName = "RewardList", menuName = "ScriptableObj/RewardList", order = 5)]
    public class RewardScriptableObject : ScriptableObject
    {
        public List<RewardInfo> rewardsList;
    }

    public enum RewardStatus { Locked, Unlocked }

    [System.Serializable]
    public struct RewardInfo
    {
        public string rewardType;
        public RewardType unlockType;
        public int achievementIndex;
        public GameObject rewardPrefab;
        public RewardStatus rewardStatus;
    }
}