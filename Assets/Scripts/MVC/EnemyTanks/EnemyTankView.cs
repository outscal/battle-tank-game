using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Outscal.BattleTank
{
    /// <summary>
    /// creating enemy tank view
    /// </summary>
    public class EnemyTankView : MonoBehaviour
    {
        #region Components And Variables
        public NavMeshAgent enemyNavMesh;
        public EnemyTankController enemyTankController;
        private BoxCollider ground;
        public float maxX, maxZ, minX, minZ;
        public float timer, patrolTime;
        public float howClose;
        public float canFire = 0f;
        public Transform BulletShootPoint;
        public MeshRenderer[] childs;

        #region EnemyTankSates
        public EnemyPatrollingState patrollingState;
        public EnemyChasingState chasingState;
        public EnemyAttackingState attackingState;
        public EnemyTankState currentState;

        #region EnemyEnums
        public EnemyState initialState;
        public EnemyState activeState;
    

        void Awake()
        {
            enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            currentState = patrollingState;
            InitializeState();
            SetGroundForEnemyPatrolling();
            //setPlayerTransform();
            timer = 5f;
            patrolTime = 2f;
            howClose = 15f;
            // Invoke("Patrol", 1f);
        }

        public void SetEnemyTankController(EnemyTankController _enemyController)
        {
            enemyTankController = _enemyController;
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
            enemyTankController.EnemyPatrollingAI();
        }

        //swith cases for different enemy states
        private void InitializeState()
        {
            switch (initialState)
            {

                case EnemyState.Attacking:
                    currentState = attackingState;
                    break;

                case EnemyState.Chasing:
                    currentState = chasingState;
                    break;

                case EnemyState.Patrolling:
                    currentState = patrollingState;
                    break;

                default:
                    currentState = null;
                    break;
            }
            currentState.OnEnterState();
        }
        //after death all the child componenets will also destroy
        public void DestroyView()
        {
            Debug.Log("Destroy Enemy View called");
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }

            BulletShootPoint = null;
            enemyNavMesh = null;
            ground = null;
            Destroy(this.gameObject);
        }
    }
}
