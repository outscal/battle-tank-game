using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Enemy
{
    public class EnemyPatrolState : EnemyState
    {
        private Rigidbody rb;
        private NavMeshAgent agent;
        private Transform playerTransform;

        private float distanceToPlayer;

        [SerializeField] private float randomPointRange = 10f;
        [SerializeField] private float navmeshPointRange = 2f;

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            playerTransform = enemyView.GetPlayerTransform();
            rb = enemyView.GetRigidbody();
            agent = enemyView.GetAgent();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public override void Tick()
        {
            base.Tick();

            Patrol();
        }

        private void Patrol()
        {
            if (playerTransform != null)
            {
                distanceToPlayer = Vector3.Distance(playerTransform.position, rb.transform.position);

                if (distanceToPlayer < enemyView.GetEnemyDetectionRange())
                {
                    enemyView.ChangeState(enemyView.enemyChaseState);
                    return;
                }
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 newPosition;

                if (RandomPosition(rb.transform.position, randomPointRange, out newPosition))
                {
                    agent.destination = newPosition;
                }
            }
        }

        private bool RandomPosition(Vector3 center, float range, out Vector3 result)
        {
            Vector3 randomPosition = center + Random.insideUnitSphere * range;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPosition, out hit, navmeshPointRange, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        }
    }
}
