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

        private void Start()
        {
            healthBar.value = fullValue;
        }

        public void SetUIColor(Color _bgColor, Color _fgColor)
        {
            backgroundImage.color = _bgColor;
            foregroundImage.color = _fgColor;
        }

        public void SetHealthBarUI(float _value)
        {
            healthBar.value = _value;
        }
    }
}