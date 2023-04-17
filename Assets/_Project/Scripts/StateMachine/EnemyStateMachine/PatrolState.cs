
namespace BattleTank.StateMachine.EnemyState
{
    public class PatrolState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public PatrolState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.GetPatrolDestination());
            enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if (enemyStateMachine.IsPlayerTankInChaseRange())
            {
                stateMachine.SetState(enemyStateMachine.ChaseState);
            }
            else if (enemyStateMachine.NavMeshAgent.remainingDistance <= enemyStateMachine.NavMeshAgent.stoppingDistance)
            {
                stateMachine.SetState(enemyStateMachine.IdleState);
            }
        }
    }
}