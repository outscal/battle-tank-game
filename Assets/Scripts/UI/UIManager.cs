using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
    
        public int playerScore = 0;

        public int hiScore { get; private set; }

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
    }
}