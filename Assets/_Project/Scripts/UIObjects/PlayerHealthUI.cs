using UnityEngine;
using UnityEngine.UI;

namespace BattleTank.UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image foregroundImage;
        [SerializeField] private Slider healthBar;
        [SerializeField] private int fullValue;
        [SerializeField] private float bgColorTransparencyValue;

        public void SetPlayerHealthValueUI()
        {
            healthBar.value = fullValue;
        }

        public void SetUIColor(Color _color)
        {
            backgroundImage.color = _color;
            foregroundImage.color = _color;

            Color bgColor = backgroundImage.color;
            bgColor.a = bgColorTransparencyValue;
            backgroundImage.color = bgColor;
        }

        public void SetHealthBarUI(float _value)
        {
            healthBar.value = _value;
        }
    }
}