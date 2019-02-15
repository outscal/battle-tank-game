using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText, scoreText;
        [SerializeField] private GameObject MiniMap;

        public GameObject MiniMapObj { get { return MiniMap; } }

        public void setHealth(int health)
        {
            healthText.text = "HP:" + health;
        }

        public void setScore(int score)
        {
            scoreText.text = "Score:" + score;
        }

    }
}