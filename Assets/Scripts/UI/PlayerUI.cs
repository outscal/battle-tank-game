using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText, scoreText;
        [SerializeField] private GameObject MiniMap;
        [SerializeField] private RawImage rawImage;

        public void SetMiniMap(Camera miniMapCam)
        {
            rawImage.texture = miniMapCam.targetTexture;
        }

        public void setHealth(int health)
        {
            healthText.text = "HP:" + health;
        }

        public void setScore(int score)
        {
            Debug.Log("[PLayerUI]IncreaseScore: " + score);

            scoreText.text = "Score:" + score;
        }

    }
}