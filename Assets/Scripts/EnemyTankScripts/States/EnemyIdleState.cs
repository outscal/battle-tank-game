using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Enemy
{
    public class EnemyIdleState : EnemyState
    {
        private Rigidbody rb;
        private NavMeshAgent agent;
        private Transform playerTransform;

        private float timeElapsed;
        private float distanceToPlayer;

        [SerializeField] private float timeToWait = 2f;

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            timeElapsed = 0f;
            rb = enemyView.GetRigidbody();
            playerTransform = enemyView.GetPlayerTransform();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public override void Tick()
        {
            base.Tick();

            if (playerTransform)
                CheckForChaseOrAttack();

            if (IdleTimeLimitReached())
                enemyView.ChangeState(enemyView.enemyPatrolState);
        }

        private void CheckForChaseOrAttack()
        {
            distanceToPlayer = Vector3.Distance(playerTransform.position, rb.transform.position);

            if (distanceToPlayer < enemyView.GetEnemyDetectionRange())
            {
                enemyView.ChangeState(enemyView.enemyChaseState);
                return;
            }
            else if (distanceToPlayer < enemyView.GetEnemyVisibilityRange())
            {
                enemyView.ChangeState(enemyView.enemyAttackState);
                return;
            }
        }

        private bool IdleTimeLimitReached()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed > timeToWait)
                return true;
            else
                return false;
        }
    }
}
