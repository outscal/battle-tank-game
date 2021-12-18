using BattleTank;
using Ground;
using TankServices;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyServices
{
    public class EnemyView : MonoBehaviour
    {
        [HideInInspector] public float maxX, maxZ, minX, minZ;
        [HideInInspector] public Transform playerTransform;
        [HideInInspector] public bool detectPlayer;
        [HideInInspector] public EnemyStateEnum activeState;
        [HideInInspector] public float timer;
        private Collider ground;
        
        public Transform shootPoint;
        public EnemyController enemyController;
        public NavMeshAgent agent;
        public float patrolTime;
        public float followRadius;
        public float canFire;
        public MeshRenderer[] enemyChilds;

        public EnemyAttack attackState;
        public EnemyFollow followState;
        public EnemyPatrol patrolState;
        public EnemyStateEnum initialState;
        public EnemyState currentState;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            currentState = patrolState;
            InitializeState();
            setGround();
            setPlayerTransform();
        }

        private void setPlayerTransform()
        {
            playerTransform = TankService.Instance.PlayerPos();
        }

        private void setGround()
        {
            ground = GroundCollider.groundBoxCollider;
            maxX = ground.bounds.max.x;
            maxZ = ground.bounds.max.z;
            minX = ground.bounds.min.x;
            minZ = ground.bounds.min.z;
        }

        public void setEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        private void Update()
        {
            enemyController.Move();
        }

        private void InitializeState()
        {
            switch (initialState)
            {
                case EnemyStateEnum.Follow:
                    currentState = followState;
                    break;

                case EnemyStateEnum.Patrol:
                    currentState = patrolState;
                    break;

                case EnemyStateEnum.Attack:
                    currentState = attackState;
                    break;

                default:
                    currentState = null;
                    break;
            }
            currentState.OnStateEnter();
        }

        public void destroyView()
        {
            for (int i = 0; i < enemyChilds.Length; i++)
            {
                enemyChilds[i] = null;
            }

            shootPoint = null;
            agent = null;
            ground = null;
            playerTransform = null;
            Destroy(this.gameObject);
        }
    }
}
