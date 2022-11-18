using GameServices;
using UnityEngine;
using TankServices;
using UnityEngine.AI;
using AllServices;
using UnityEngine.UI;
//using EnemyTankServices;

namespace EnemyTankServices
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
        public EnemyTankController enemyTankController; 
        [HideInInspector] public Transform playerTransform; // Reference to player position.
        public NavMeshAgent navAgent;
        public Transform turret;

        public Transform fireTransform; // Bullet spawn position.
        public LayerMask playerLayerMask; // For player detection.
        public LayerMask groundLayerMask; // For ground detection.

        public GameObject explosionEffectPrefab; // Explosion effect particle system prefab.

        public EnemyPatrollingState patrollingState; // Patrolling behaviour script.
        public EnemyChasingState chasingState; // Chasing behaviour script.
        public EnemyAttackingState attackingState; // Attacking behaviour script.

        [SerializeField] private EnemyState initialState;
        [HideInInspector] public EnemyState activeState;
        [HideInInspector] public EnemyTankBaseStates currentState;

        [HideInInspector] public AudioSource explosionSound;
        [HideInInspector] public ParticleSystem explosionParticles;

        public AudioSource shootingAudio;
        public AudioClip fireClip;

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        private void Awake()
        {
            explosionParticles = Instantiate(explosionEffectPrefab).GetComponent<ParticleSystem>();
            explosionSound = explosionParticles.GetComponent<AudioSource>();

            explosionParticles.gameObject.SetActive(false);
        }

        private void Start()
        {
            enemyTankController.SetHealthUI();

            if (TankService.Instance.playerTankView)
            {
                playerTransform = TankService.Instance.playerTankView.transform;
            }

            navAgent = GetComponent<NavMeshAgent>();
            SetEnemyTankColor();
            InitializeState();

            CameraController.Instance.AddCameraTargetPosition(this.transform);
        }

        private void FixedUpdate()
        {
            enemyTankController.RangeCheck();            
        }

        // Sets material color of all child mesh renderers.
        public void SetEnemyTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = enemyTankController.enemyTankModel.tankColor;
            }
        }

        public float GetRandomLaunchForce()
        {
            return Random.Range(enemyTankController.enemyTankModel.minLaunchForce, enemyTankController.enemyTankModel.maxLaunchForce);
        }

        // Implementation of IDamagable interface. 
        public void TakeDamage(int damage)
        {
            enemyTankController.TakeDamage(damage);
        }

        public void Death()
        {
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            Destroy(gameObject);
        }

        private void InitializeState()
        {
            switch (initialState)
            {
                case EnemyState.Attacking:
                    {
                        currentState = attackingState;
                        break;
                    }
                case EnemyState.Chasing:
                    {
                        currentState = chasingState;
                        break;
                    }
                case EnemyState.Patrolling:
                    {
                        currentState = patrollingState;
                        break;
                    }
                default:
                    {
                        currentState = null;
                        break;
                    }
            }
            currentState.OnStateEnter();
        }
    }
}
