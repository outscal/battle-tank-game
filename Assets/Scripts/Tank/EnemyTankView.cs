using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(States.IdleState))]
    [RequireComponent(typeof(States.ChaseState))]
    [RequireComponent(typeof(States.PatrolState))]
    [RequireComponent(typeof(States.AttackState))]
    public class EnemyTankView: TankView
    {
        #region Serialized Data members

        [SerializeField] private TankRadar chaseTankRadar;
        [SerializeField] private TankRadar attackTankRadar;
        [SerializeField] private Transform firingPoint;
        [SerializeField] private States.IdleState idle;
        [SerializeField] private States.PatrolState patrolling;
        [SerializeField] private States.ChaseState chasing;
        [SerializeField] private States.AttackState attacking;

        #endregion

        #region Private Data members

        private NavMeshAgent _navMeshAgent;
        private States.State _currentState;

        #endregion
        
        #region Unity Functions

        private void OnEnable()
        {
            
            chaseTankRadar.PlayerFound += PlayerDetected;
            chaseTankRadar.PlayerEscaped += PlayerLost;

            attackTankRadar.PlayerFound += AbleToAttack;
            attackTankRadar.PlayerEscaped += AttackTargetLost;
        }

        private void OnDisable()
        {
            chaseTankRadar.PlayerFound -= PlayerDetected;
            chaseTankRadar.PlayerEscaped -= PlayerLost;
            
            attackTankRadar.PlayerFound -= AbleToAttack;
            attackTankRadar.PlayerEscaped -= AttackTargetLost;
        }

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        

        private void Start()
        {
            chaseTankRadar.GetComponent<SphereCollider>().radius =
                ((EnemyTankModel) _tankController.TankModel).AiAgentModel.RadarRange;
            attackTankRadar.GetComponent<SphereCollider>().radius = 
                ((EnemyTankModel) _tankController.TankModel).AiAgentModel.AttackRange;
        }

        #endregion
        
        #region Private Functions

        private void PlayerDetected(PlayerTankView player)
        {
            ((EnemyTankController)_tankController).PlayerFound(player);
        }

        private void PlayerLost()
        {
            ((EnemyTankController)_tankController).PlayerLost();
        }

        #endregion
        
        #region Getters

        public Transform FiringPoint => firingPoint;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public States.State CurrentState => _currentState;
        public States.IdleState Idle => idle;
        public States.PatrolState Patroll => patrolling;
        public States.ChaseState Chase => chasing;
        public States.AttackState Attack => attacking;

        #endregion

        #region Public Functions

        public void ChangeStateTo(States.State newState)
        {
            if(_currentState) _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void TimeToMove()
        {
            ((EnemyTankController)_tankController).Move();
        }

        public void AbleToAttack(PlayerTankView player)
        {
            ((EnemyTankController)_tankController).HandleAttacks(player);
        }

        public void AttackTargetLost()
        {
            ((EnemyTankController)_tankController).ReturnToChase();
        }

        #endregion
    }
}