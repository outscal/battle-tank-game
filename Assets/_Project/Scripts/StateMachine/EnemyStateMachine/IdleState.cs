using UnityEngine;

namespace BattleTank.StateMachine.EnemyState
{
    public class IdleState : BaseState
    {
        private float idleTime;
        private float patrolTime;
        private float defaultPatrolTime;
        private EnemyStateMachine enemyStateMachine;

        public IdleState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
            idleTime = enemyStateMachine.GetIdleTime();
            defaultPatrolTime = enemyStateMachine.GetDefaultPatrolTime();
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.isStopped = true;
            patrolTime = defaultPatrolTime;
        }

        public override void Tick()
        {
            patrolTime += Time.deltaTime;
            if(patrolTime > idleTime)
            {
                stateMachine.SetState(enemyStateMachine.PatrolState);
            }
            else if (enemyStateMachine.IsPlayerTankInChaseRange())
            {
                stateMachine.SetState(enemyStateMachine.ChaseState);
            }
        }
    }
}