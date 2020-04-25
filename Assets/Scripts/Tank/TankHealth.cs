using UnityEngine;
using UnityEngine.UI;

namespace Tank
{
    public class TankHealth : MonoBehaviour, IDestructable
    {           
        public Slider Slider;                             
        public Image FillImage;                           
        public Color FullHealthColor = Color.green;  
        public Color ZeroHealthColor = Color.red;

        private float startingHealth;
        private TankController controller;
        [SerializeField]
        private float currentHealth;                                                   

        public void Initialize (TankController _controller)
        {
            controller = _controller;

            startingHealth = controller.GetModel().Health;

            SetTankHealth(startingHealth);
        }


        private void SetTankHealth(float health)
        {
            currentHealth = health;

            SetHealthUI();
        }


        public void TakeDamage (float amount)
        {
            currentHealth -= amount;

            SetHealthUI ();

            if (currentHealth <= 0f)
            {
                controller.OnDeath ();
            }
        }


        private void SetHealthUI ()
        {
            Slider.value = currentHealth;

            FillImage.color = Color.Lerp (ZeroHealthColor, FullHealthColor, currentHealth / startingHealth);
        }
    }
}