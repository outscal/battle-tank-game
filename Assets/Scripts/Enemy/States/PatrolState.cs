using UnityEngine;
using UnityEngine.AI;

namespace EnemyStates
{
    public class PatrolState : EnemyState
    {
        private Vector3 m_CurrentWaypoint;
        private float m_PatrolRadius = 30f;

        private int m_WaypointFinderMaxIterations = 8;  // Max number of times we'll try to find a valid point.
        private float m_WaypointTolerance = 0.5f; // Distance within which waypoint is considered reached

        private Vector3 m_PreviousPosition;
        private float m_DeltaSquareMagnitudeThreshold = 0.1f;
        private float m_StuckTimer = 0f;
        private float m_TimeToConsiderStuck = 1f; // Amount of time after which we consider the agent stuck.

        public PatrolState(EnemyView enemyView) : base(enemyView) { }

        public override void OnStateEnter()
        {
            enemyView.NavMeshAgent.isStopped = false;
            SetRandomWaypoint();
        }

        public override void Tick()
        {
            // Check if the agent is moving
            if ((enemyView.transform.position - m_PreviousPosition).sqrMagnitude < m_DeltaSquareMagnitudeThreshold)
            {
                m_StuckTimer += Time.deltaTime;
                if (m_StuckTimer >= m_TimeToConsiderStuck)
                {
                    // The agent is probably stuck, re-evaluate the waypoint
                    SetRandomWaypoint();
                    m_StuckTimer = 0f;
                }
            }
            else
            {
                m_StuckTimer = 0f;
            }

            m_PreviousPosition = enemyView.transform.position;
            
            // If the enemy is close enough to the current waypoint, move to the next one
            if (Vector3.Distance(enemyView.transform.position, m_CurrentWaypoint) < m_WaypointTolerance)
            {
                SetRandomWaypoint();
            }
            
            // If the player is detected, transition to the chase state
            if (enemyView.PlayerInDetectionRange())
            {
                enemyView.SetState(new ChaseState(enemyView));
            }
        }

        public override void OnStateExit()
        {
            enemyView.NavMeshAgent.isStopped = true;
        }

        private void SetRandomWaypoint()
        {
            for (int i = 0; i < m_WaypointFinderMaxIterations; i++)
            {
                Vector3 randomDirection = Random.insideUnitSphere * m_PatrolRadius;
                randomDirection += enemyView.transform.position;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, m_PatrolRadius, NavMesh.AllAreas))
                {
                    m_CurrentWaypoint = hit.position;
                    enemyView.NavMeshAgent.SetDestination(m_CurrentWaypoint);

                    if (enemyView.NavMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
                    {
                        // We've found a valid path. No need to search further.
                        return;
                    }
                }
            }

            // If we reach here, it means we couldn't find a valid point after 'attempts' tries.
            // Handle this case as needed (e.g., log a warning, default to a safe position, etc.)
            Debug.LogWarning("Could not find a valid patrol point after multiple attempts.");
        }
    }
}