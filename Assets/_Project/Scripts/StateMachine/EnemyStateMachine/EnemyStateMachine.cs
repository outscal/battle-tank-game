using BattleTank.EnemyTank;
using BattleTank.Enum;
using BattleTank.Services;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.StateMachine.EnemyState
{
    public class EnemyStateMachine : StateMachine
    {
        [SerializeField] private float patrolRange;
        [SerializeField] private float chaseRange;
        [SerializeField] private float attackRange;
        [SerializeField] private float averageDistance;
        [SerializeField] private float nextShootTime;
        [SerializeField] private float defaultWaitTime;
        [SerializeField] private float idleTime;
        [SerializeField] private float defaultPatrolTime;

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
        
        private void Initialize()
        {
            PlayerTransform = PlayerTankService.Instance.GetPlayerTank();

            IdleState = new IdleState(this);
            PatrolState = new PatrolState(this);
            ChaseState = new ChaseState(this);
            AttackState = new AttackState(this);
            DeadState = new DeadState(this);
        }

        private void StartStateMachine()
        {
            SetState(IdleState);
        }

        public void SetComponentsInEnemyStateMachine(EnemyTankController _enemyTankController, EnemyTankView _enemyTankView, NavMeshAgent _navMeshAgent, BulletType _bulletType)
        {
            enemyTankController = _enemyTankController;
            EnemyTankView = _enemyTankView;
            NavMeshAgent = _navMeshAgent;
            EnemyBulletType = _bulletType;

            Initialize();
            StartStateMachine();
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
            ParticleEffectsService.Instance.ShowExplosionEffect(ExplosionType.TankExplosion, EnemyTankView.transform.position);
            SoundService.Instance.PlayEffects(Sounds.TankExplosion);
            EnemyTankService.Instance.GetEnemyTankPoolService().ReturnItem(ObjectPoolType.EnemyTankPool, EnemyTankView);
            if (PlayerTankService.Instance.GetIsPlayerTankAlive())
            {
                EnemyTankService.Instance.SpawnEnemyTanks();
            }
        }

        public float GetNextShootTime()
        {
            return nextShootTime;
        }
        
        public float GetDefaultWaitTime()
        {
            return defaultWaitTime;
        }

        public float GetIdleTime()
        {
            return idleTime;
        }

        public float GetDefaultPatrolTime()
        {
            return defaultPatrolTime;
        }
    }
}