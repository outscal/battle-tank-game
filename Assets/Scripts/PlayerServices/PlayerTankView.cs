using GameplayServices;
using GlobalServices;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerTankServices
{
    // Script is present on visual instance of player tank.
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : MonoBehaviour, IDamagable
    {        
        public GameObject turret; // Player tank turret.
        public GameObject explosionEffectPrefab; // Explosion effect particle system prefab.

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        // To display aim arrow.
        public Transform fireTransform;
        public Slider aimSlider;

        // For movement audio.
        public AudioSource movementAudio;
        public AudioClip engineIdling;
        public AudioClip engineDriving;

        [HideInInspector] public AudioSource explosionSound;
        [HideInInspector] public ParticleSystem explosionParticles;

        public AudioSource shootingAudio;
        public AudioClip chargingClip;
        public AudioClip fireClip;

        private PlayerTankController tankController;

        private void Awake()
        {
            // Instantiate the explosion prefab and get a reference to the particle system on it.
            explosionParticles = Instantiate(explosionEffectPrefab).GetComponent<ParticleSystem>();
            explosionSound = explosionParticles.GetComponent<AudioSource>();

            // Disable the prefab so it can be activated when it's required.
            explosionParticles.gameObject.SetActive(false);  
        }

        private void Start()
        {
            tankController.SetHealthUI();
            tankController.SetAimUI();
            SetPlayerTankColor();

            // Add's reference of tank position in camera targets list.
            CameraController.Instance.AddCameraTargetPosition(this.transform);
        }

        public void SetTankControllerReference(PlayerTankController controller)
        {
            tankController = controller;
        }

        public void Death()
        {
            // Removes reference of tank position in camera targets list.
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            Destroy(gameObject);
        }

        // Implementation of IDamagable interface.
        public void TakeDamage(int damage)
        {
            tankController.TakeDamage(damage); 
        }

        // Sets material color of all child mesh renderers.
        public void SetPlayerTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = tankController.tankModel.tankColor;
            }
        }
    }
}
