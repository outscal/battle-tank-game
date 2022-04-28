using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using PlayerTankServices;
using GlobalServices;
using GameplayServices;


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

        public Patrolling patrollingState;
        public Chasing chasingState;
        public Attacking attackingState;

        [SerializeField] private EnemyState initialState;
        [HideInInspector] public EnemyState activeState;
        [HideInInspector] public EnemyStates currentState;

        // To display health.
        public Slider healthSlider;
        public Image fillImage;

        [HideInInspector] public Transform playerTransform;
        [HideInInspector] public EnemyTankController tankController;

        [HideInInspector] public AudioSource explosionSound;
        [HideInInspector] public ParticleSystem explosionParticles;

        public AudioSource shootingAudio;
        public AudioClip fireClip;
        UIServices.UIHandler uiHandler;

        private void Awake()
        {
            explosionParticles = Instantiate(explosionEffectPrefab).GetComponent<ParticleSystem>();
            explosionSound = explosionParticles.GetComponent<AudioSource>();
            explosionParticles.gameObject.SetActive(false);
        }

        private void Start()
        {
            tankController.SetHealthUI();

            if (PlayerTankService.Instance.playerTankView)
            {
                playerTransform = PlayerTankService.Instance.playerTankView.transform;
            }

            navAgent = GetComponent<NavMeshAgent>();
            SetEnemyTankColor();
            InitializeState();

            CameraController.Instance.AddCameraTargetPosition(this.transform);
        }

        private void FixedUpdate()
        {
            tankController.UpdateTankController();
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

            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            StartCoroutine("DeathAfterDelay");
            Destroy(gameObject);
        }
        IEnumerator DeathAfterDelay()
        {
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionSound.Play();
            explosionParticles.Play();
            yield return new WaitForSeconds(1.5f);
            explosionParticles.gameObject.SetActive(false);
            CameraController.Instance.SetCameraWithEndTargets();
        }

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
