using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Outscal.BattleTank
{
    /// <summary>
    /// creating enemy tank view
    /// </summary>
    public class EnemyTankView : MonoBehaviour,IDamagable
    {
        public NavMeshAgent navMeshAgent;
        public EnemyTankController enemyTankController;
        public float maxZ, maxX, minZ, minX;
        public Transform bulletShootPoint;
        public float patrollTime;
        public float howClose;
        public float timer;
        public float canFire=0f;
        private BoxCollider ground;
        public MeshRenderer[] childs;

       //[HideInInspector] public Transform playerTransform;
       //[HideInInspector]public EnemyPatrollingState patrollingState;
       //[HideInInspector]public EnemyChasingState chasingState;
       //[HideInInspector]public EnemyAttackingState attackingState;
       //private EnemyState initialState;
       //[HideInInspector]public EnemyState activeState;
       //private EnemyTankState currentState;

        public Transform playerTransform;
        public EnemyPatrollingState patrollingState;
        public EnemyChasingState chasingState;
        public EnemyAttackingState attackingState;
        private EnemyState initialState;
        public EnemyState activeState;
        private EnemyTankState currentState;

        private void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            currentState = patrollingState;
            //InitializeState();
            SetGroundForEnemyPatrolling();
            SetPlayerTransform();
            timer = 0;
            patrollTime = 5f;
            howClose = 20f;
            //Invoke("Patrol", 1f);
            //ChangeState(patrollingState);
        }

        private void SetGroundForEnemyPatrolling()
        {
            ground = GroundBoxCollider.groundBoxCollider;
            maxX = ground.bounds.max.x;
            maxZ = ground.bounds.max.z;
            minX = ground.bounds.min.x;
            minZ = ground.bounds.min.z;
        }

        void Update()
        {
            //InitializeState();
            enemyTankController.EnemyPatrollingAI();
        }

        public void SetEnemyTankController(EnemyTankController _enemyTankController) 
        {
            enemyTankController = _enemyTankController;
        }

        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 randomDir = new Vector3(x, 0, z);
            return randomDir;
        }

        public void SetPatrollingDestination()
        {        
            Vector3 newDestnation = GetRandomPosition();
            navMeshAgent.SetDestination(newDestnation);
        }

        private void SetPlayerTransform()
        {
            playerTransform = TankService.Instance.PlayerPos();
        }

        public Transform GetTankTransform()
        {
            return this.transform;
        }

        private void InitializeState()
        {
            switch (initialState)
            {
                case EnemyState.Patrolling:
                    currentState = patrollingState;
                    break;
                case EnemyState.Attacking:
                    currentState = attackingState;
                    break;

                case EnemyState.Chasing:
                    currentState = chasingState;
                    break;

                default:
                    currentState = null;
                    break;
            }
            currentState.OnEnterState();
        }

        public void DestroyView()
        {
            Debug.Log("Destroy Enemy View called");
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }
            bulletShootPoint = null;
            navMeshAgent = null;
            ground = null;
            Destroy(this.gameObject);
        }

        public void TakeDamage(int damage)
        {
            enemyTankController.ApplyDamage(damage);
        }

        public void ChangeState(EnemyTankState newState)
        {
            if (currentState != null)
                currentState.OnExitState();

            currentState = newState;
            currentState.OnEnterState();
        }
    }
}