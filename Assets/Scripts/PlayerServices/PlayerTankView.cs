using GameplayServices;
using GlobalServices;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace PlayerTankServices
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : MonoBehaviour, IDamagable
    {
        public GameObject tankHead;
        public GameObject explosionEffectPrefab;

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        // To display aim arrow.
        public Transform fireTransform;
        public Slider aimSlider;

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

        public void SetTankControllerReference(PlayerTankController controller)
        {
            tankController = controller;
        }

        public void Death()
        {
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            CameraController.Instance.SetCameraWithEndTargets();
            StartCoroutine("TankExplosion");
            Destroy(gameObject);
        }
        IEnumerator TankExplosion()
        {
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionSound.Play();
            explosionParticles.Play();
            yield return new WaitForSeconds(5f);
        }

        public void TakeDamage(int damage)
        {
            tankController.TakeDamage(damage);
        }

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
