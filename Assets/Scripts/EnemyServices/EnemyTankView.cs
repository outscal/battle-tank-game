using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using PlayerTankServices;
using GlobalServices;
using GameplayServices;

namespace EnemyTankServices
{
    // Script is present on visual instance of enemy tank.
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
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
        [HideInInspector] public EnemyStates currentState;

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        [HideInInspector] public Transform playerTransform; // Reference to player position.
        [HideInInspector] public EnemyTankController tankController;

        [HideInInspector] public AudioSource explosionSound;
        [HideInInspector] public ParticleSystem explosionParticles;

        public AudioSource shootingAudio;
        public AudioClip fireClip;

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
        
            // If player is spawnned, we take reference of player transform.
            if(PlayerTankService.Instance.playerTankView)
            {
                playerTransform = PlayerTankService.Instance.playerTankView.transform;
            }

            navAgent = GetComponent<NavMeshAgent>();         
            SetEnemyTankColor();
            InitializeState();

            // Add's reference of tank position in camera targets list.
            CameraController.Instance.AddCameraTargetPosition(this.transform);
        }

        private void FixedUpdate()
        {
            tankController.UpdateTankController();
        }

        // To set initial state of enemy tank.
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

        // Returns random launch force value between minimum and maximum lauch force.
        public float GetRandomLaunchForce()
        {
            return Random.Range(tankController.tankModel.minLaunchForce, tankController.tankModel.maxLaunchForce);
        }

        // Implementation of IDamagable interface. 
        public void TakeDamage(int damage)
        {
            tankController.TakeDamage(damage);
        }

        public void Death()
        {
            // Removes reference of tank position in camera targets list.
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            Destroy(gameObject);
        }

        // Sets material color of all child mesh renderers.
        public void SetEnemyTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = tankController.tankModel.tankColor;
            }
        }
    }
}
