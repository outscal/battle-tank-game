using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using PlayerTankServices;
using GlobalServices;

namespace EnemyTankServices
{
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
        public NavMeshAgent navAgent;
        public Transform turret;

        public Transform fireTransform;
        public LayerMask playerLayerMask;
        public LayerMask groundLayerMask;
        public GameObject explosionEffectPrefab;

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        [HideInInspector] public Transform playerTransform;
        [HideInInspector] public EnemyTankController tankController;

        [HideInInspector]
        public AudioSource explosionSound;
        [HideInInspector]
        public ParticleSystem explosionParticles;

        public AudioSource shootingAudio;
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
        
            if(PlayerTankService.Instance.playerTankView)
            {
                playerTransform = PlayerTankService.Instance.playerTankView.transform;
            }

            navAgent = GetComponent<NavMeshAgent>();
            tankController.ChangeWalkPoint();
        }

        private void FixedUpdate()
        {
            tankController.UpdateTankController();
        }

        public float GetRandomLaunchForce()
        {
            return Random.Range(tankController.tankModel.minLaunchForce, tankController.tankModel.maxLaunchForce);
        }

        public void TakeDamage(int damage)
        {
            tankController.TakeDamage(damage);
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}
