using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Enemy
{
    public class EnemyChaseState : EnemyState
    {
        private Transform playerTransform;
        private NavMeshAgent agent;

        private float playerDetectionRange;

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            playerTransform = enemyView.GetPlayerTransform();
            agent = enemyView.GetAgent();
            playerDetectionRange = enemyView.GetEnemyDetectionRange();

            agent.SetDestination(playerTransform.position);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public override void Tick()
        {
            base.Tick();

            if (playerTransform == null)
            {
                enemyView.ChangeState(enemyView.enemyIdleState);
                return;
            }

            Chase();
        }

        public void Chase()
        {
            if (agent.remainingDistance > playerDetectionRange)
            {
                enemyView.ChangeState(enemyView.enemyIdleState);
            }
            else if (agent.remainingDistance < enemyView.GetEnemyVisibilityRange())
            {
                enemyView.ChangeState(enemyView.enemyAttackState);
            }
            else
            {
                agent.SetDestination(playerTransform.position);
            }
        }
    }
}
