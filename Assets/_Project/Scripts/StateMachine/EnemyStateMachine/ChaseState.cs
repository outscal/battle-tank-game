using BattleTank.Services;

namespace BattleTank.StateMachine.EnemyState
{
    public class ChaseState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public ChaseState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if (enemyStateMachine.IsPlayerTankInAttackRange())
            {
                stateMachine.SetState(enemyStateMachine.AttackState);
            }
            else if (enemyStateMachine.IsPlayerTankInChaseRange())
            {
                enemyStateMachine.NavMeshAgent.SetDestination(enemyStateMachine.PlayerTransform.position);
            }
            else
            {
                stateMachine.SetState(enemyStateMachine.IdleState);
                EventService.Instance.OnPlayerEscaped();
            }
        }
    }
}