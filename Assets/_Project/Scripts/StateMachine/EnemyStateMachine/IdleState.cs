using UnityEngine;

namespace BattleTank.StateMachine.EnemyState
{
    public class IdleState : BaseState
    {
        private float patrolTime;
        private float idleTime;
        private EnemyStateMachine enemyStateMachine;

        public IdleState(EnemyStateMachine _enemyStateMachine) : base(_enemyStateMachine)
        {
            enemyStateMachine = _enemyStateMachine;
            idleTime = 3f;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.NavMeshAgent.isStopped = true;
            patrolTime = 0f;
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