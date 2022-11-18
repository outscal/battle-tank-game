using UnityEngine;
using GameServices;
using UnityEngine.UI;
using AllServices;

/// <summary>
/// This Class is Attached to a Player Tank GameObject and is responsible for UI related work.
/// </summary>

namespace TankServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankView : MonoBehaviour, IDamagable
    {
        private TankController tankController;

        public GameObject turret;

        // To display aim arrow.
        public Transform fireTransform;

        public GameObject explosionEffectPrefab; // Explosion effect particle system prefab.

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

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
            SetPlayerTankColor();

            CameraController.Instance.AddCameraTargetPosition(this.transform);
        }

        public void SetTankControllerReference(TankController tankController)
        {
            this.tankController = tankController;
        }

        public void Death()
        {
            Debug.Log("Destroy PlayerTank");
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            Destroy(gameObject);

        }

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
                renderers[i].material.color = tankController.tankModel.TankColor;
            }
        }
    }
}
