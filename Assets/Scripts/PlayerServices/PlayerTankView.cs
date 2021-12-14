using GlobalServices;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerTankServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : MonoBehaviour, IDamagable
    {
        public GameObject turret;
        public GameObject explosionEffectPrefab;

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        // To display aim arrow.
        public Transform fireTransform;
        public Slider aimSlider;

        [HideInInspector]
        public AudioSource explosionSound;
        [HideInInspector]
        public ParticleSystem explosionParticles;

        public AudioSource shootingAudio;
        public AudioClip chargingClip;
        public AudioClip fireClip;

        private PlayerTankController tankController;

        private void Awake()
        {
            explosionParticles = Instantiate(explosionEffectPrefab).GetComponent<ParticleSystem>();
            explosionSound = explosionParticles.GetComponent<AudioSource>();
            explosionParticles.gameObject.SetActive(false);
        }

        private void Start()
        {
            tankController.SetHealthUI();
            tankController.SetAimUI();
        }

        public void SetTankControllerReference(PlayerTankController controller)
        {
            tankController = controller;
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            tankController.TakeDamage(damage); 
        }
    }
}
