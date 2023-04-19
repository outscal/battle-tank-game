using UnityEngine;
using UnityEngine.UI;

namespace BattleTank.UI
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image foregroundImage;
        [SerializeField] private Slider healthBar;
        [SerializeField] private int fullValue;
        [SerializeField] private float defaultXAxis;
        [SerializeField] private float bgColorTransparencyValue;
        private Transform playerTransform;
        
        private void Update()
        {
            transform.LookAt(playerTransform);
            transform.rotation = Quaternion.Euler(new Vector3(defaultXAxis, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        }

        public void SetUIColor(Color _color)
        {
            backgroundImage.color = _color;
            foregroundImage.color = _color;

            Color bgColor = backgroundImage.color;
            bgColor.a = bgColorTransparencyValue;
            backgroundImage.color = bgColor;

            SetHealthBarValue();
        }

        private void SetHealthBarValue()
        {
            healthBar.value = fullValue;
        }

        public void SetHealthBarUI(float _value)
        {
            healthBar.value = _value;
        }

        public void SetPlayerTransform(Transform transform)
        {
            playerTransform = transform;
        }
    }
}