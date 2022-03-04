using System;
using Tank.States;
using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IdleState))]
    [RequireComponent(typeof(ChaseState))]
    [RequireComponent(typeof(PatrolState))]
    [RequireComponent(typeof(AttackState))]
    public class EnemyTankView: TankView
    {
        [SerializeField] private TankRadar chaseTankRadar;
        [SerializeField] private TankRadar attackTankRadar;
        [SerializeField] private Transform firingPoint;

        public Transform FiringPoint => firingPoint;
        private NavMeshAgent _navMeshAgent;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        [SerializeField] private IdleState idle;
        [SerializeField] private PatrolState patrolling;
        [SerializeField] private ChaseState chasing;
        [SerializeField] private AttackState attacking;

        private State _currentState;
        public State CurrentState => _currentState;

        public IdleState Idle => idle;
        public PatrolState Patroll => patrolling;
        public ChaseState Chase => chasing;
        public AttackState Attack => attacking;

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

        public void ChangeStateTo(State newState)
        {
            if(_currentState) _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private void PlayerDetected(PlayerTankView player)
        {
            ((EnemyTankController)_tankController).PlayerFound(player);
        }

        private void PlayerLost()
        {
            ((EnemyTankController)_tankController).PlayerLost();
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
    }
}