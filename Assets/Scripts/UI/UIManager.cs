using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
    
        public int playerScore = 0;

        public int hiScore { get; private set; }

        public event Action<int> ScoreIncreased;

        public void SetHiScore(int value)
        {
            hiScore = value;
            PlayerPrefs.SetInt("HiScore", hiScore);
        }

        public void Start()
        {
            if (PlayerPrefs.HasKey("HiScore"))
                hiScore = PlayerPrefs.GetInt("HiScore");
            else
                hiScore = 0;
        }

        public void InvokeScoreIncreasedAction(int playerID)
        {
            ScoreIncreased?.Invoke(playerID);
        }
    }
}