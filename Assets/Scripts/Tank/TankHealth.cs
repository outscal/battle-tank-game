using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Generic
{
    public class TankHealth : MonoBehaviour
    {           
        public Slider Slider;                             
        public Image FillImage;                           
        public Color FullHealthColor = Color.green;       
        public Color ZeroHealthColor = Color.red;         
        //public GameObject ExplosionPrefab;

        private float startingHealth;
        private IController controller;
        //private ParticleSystem explosionParticles;        
        [SerializeField]
        private float currentHealth;                                                   

        public void Initialize (IController _controller)
        {
            controller = _controller;
            //explosionParticles = Instantiate (ExplosionPrefab).GetComponent<ParticleSystem> ();

            //explosionParticles.gameObject.SetActive (false);
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
                controller.OnDeath (transform.position);
            }
        }


        private void SetHealthUI ()
        {
            Slider.value = currentHealth;

            FillImage.color = Color.Lerp (ZeroHealthColor, FullHealthColor, currentHealth / startingHealth);
        }
    }
}