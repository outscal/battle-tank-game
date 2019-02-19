using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Reward;

namespace UI
{
    public class RewardButton : MonoBehaviour
    {
        public Button button;
        public Text infoText;

        public int rewardIndex;

        private void Start()
        {
            button.onClick.AddListener(() => RewardButtonMth());
        }

        void RewardButtonMth()
        {
            RewardUI.InstanceClass.RewardButtonMth(rewardIndex);
        }

    }
}