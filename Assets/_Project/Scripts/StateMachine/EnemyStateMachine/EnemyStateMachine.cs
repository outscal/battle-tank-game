using BattleTank.EnemyTank;
using BattleTank.Enum;
using BattleTank.Services;
using BattleTank.Services.ObjectPoolService;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.StateMachine.EnemyState
{
    public class EnemyStateMachine : StateMachine
    {
        private float patrolRange;
        private float chaseRange;
        private float attackRange;
        private float averageDistance;

        private EnemyTankController enemyTankController;

        public NavMeshAgent NavMeshAgent { get; private set; }
        public Transform PlayerTransform { get; private set; }
        public BulletType EnemyBulletType { get; private set; }

        public EnemyTankView EnemyTankView { get; private set; }

        public IdleState IdleState { get; private set; }
        public PatrolState PatrolState { get; private set; }
        public ChaseState ChaseState { get; private set; }
        public AttackState AttackState { get; private set; }
        public DeadState DeadState { get; private set; }

        private void Start()
        {
            patrolRange = 300f;
            chaseRange = 23f;
            attackRange = 18f;
            averageDistance = 30f;

            PlayerTransform = PlayerTankService.Instance.GetPlayerTank();

            IdleState = new IdleState(this);
            PatrolState = new PatrolState(this);
            ChaseState = new ChaseState(this);
            AttackState = new AttackState(this);
            DeadState = new DeadState(this);

            SetState(IdleState);
        }

        public void SetComponentsInEnemyStateMachine(EnemyTankController _enemyTankController, EnemyTankView _enemyTankView, NavMeshAgent _navMeshAgent, BulletType _bulletType)
        {
            enemyTankController = _enemyTankController;
            EnemyTankView = _enemyTankView;
            NavMeshAgent = _navMeshAgent;
            EnemyBulletType = _bulletType;
        }

        private void Update()
        {
            if(currentState != null)
            {
                currentState.Tick();
            }
        }

        public bool IsPlayerTankInAttackRange()
        {
            if(PlayerTransform != null)
            {
                return Vector3.Distance(gameObject.transform.position, PlayerTransform.position) < attackRange;
            }
            return false;
        }

        public bool IsPlayerTankInChaseRange()
        {
            if (PlayerTransform != null)
            {
                return Vector3.Distance(gameObject.transform.position, PlayerTransform.position) < chaseRange;
            }
            return false;
        }

        public Vector3 GetPatrolDestination()
        {
            bool pointFound = false;
            Vector3 finalPosition = Vector3.zero;
            NavMeshHit hit;

            while (pointFound != true)
            {
                Vector3 randomDirection = gameObject.transform.position + Random.insideUnitSphere * patrolRange;

                if (NavMesh.SamplePosition(randomDirection, out hit, 1, NavMesh.AllAreas))
                {
                    finalPosition = hit.position;
                    if (Vector3.Distance(EnemyTankView.transform.position, finalPosition) > averageDistance)
                    {
                        pointFound = true;
                    }
                }
            }

            return finalPosition;
        }

        public void DestroyGameObject()
        {
            enemyTankController.SetIsTankAlive(false);
            StartCoroutine(DestroyTank());
        }

        IEnumerator DestroyTank()
        {
            yield return new WaitForSeconds(enemyTankController.GetTankDestroyTime());
            EnemyTankPoolService.Instance.ReturnItem(EnemyTankView);
        }
    }
}