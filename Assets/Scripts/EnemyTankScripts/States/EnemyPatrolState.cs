using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyState
{
    private Transform playerTransform;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private float distanceToPlayer;

    [SerializeField] private float randomPointRange = 10f;
    [SerializeField] private float navmeshPointRange = 2f;

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        playerTransform = enemyView.GetPlayerTransform();
        rb = enemyView.GetRigidbody();
        agent = enemyView.GetAgent();

        agent.speed = enemyView.GetEnemySpeed();
        agent.stoppingDistance = 2f;
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
        if (playerTransform == null)
        {
            enemyView.ChangeState(enemyView.enemyIdleState);
            return;
        }

        distanceToPlayer = Vector3.Distance(playerTransform.position, rb.transform.position);
        if (distanceToPlayer < enemyView.GetEnemyDetectionRange())
        {
            enemyView.ChangeState(enemyView.enemyChaseState);
            return;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 newPoint;
            if (RandomPoint(rb.transform.position, randomPointRange, out newPoint))
            {
                agent.destination = newPoint;
            }
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, navmeshPointRange, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
