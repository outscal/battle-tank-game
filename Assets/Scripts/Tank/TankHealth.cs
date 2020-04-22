using UnityEngine;
using UnityEngine.UI;

namespace Generic
{
    public class TankHealth : MonoBehaviour
    {           
        public Slider m_Slider;                             
        public Image m_FillImage;                           
        public Color m_FullHealthColor = Color.green;       
        public Color m_ZeroHealthColor = Color.red;         
        public GameObject m_ExplosionPrefab;

        private float m_StartingHealth;
        private IController controller;
        private AudioSource m_ExplosionAudio;               
        private ParticleSystem m_ExplosionParticles;        
        [SerializeField]
        private float m_CurrentHealth;                      
        //private bool m_Dead;                                


        public void Initialize (IController _controller)
        {
            controller = _controller;
            m_ExplosionParticles = Instantiate (m_ExplosionPrefab).GetComponent<ParticleSystem> ();

            m_ExplosionParticles.gameObject.SetActive (false);
            m_StartingHealth = controller.GetModel().M_Health;

            SetTankHealth(m_StartingHealth);
        }


        private void SetTankHealth(float health)
        {
            m_CurrentHealth = health;
            //m_Dead = false;

            SetHealthUI();
        }


        public void TakeDamage (float amount)
        {
            //Debug.Log("m_CurrentHealth " + m_CurrentHealth, this);
            m_CurrentHealth -= amount;

            SetHealthUI ();

            if (m_CurrentHealth <= 0f)
            {
                controller.OnDeath (m_ExplosionParticles, transform.position);
            }
        } 


        private void SetHealthUI ()
        {
            m_Slider.value = m_CurrentHealth;

            m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
        }
    }
}