using UnityEngine;
using UnityEngine.AI;

namespace TankBattle.Tank.EnemyTank
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;

        private NavMeshAgent agent;
        private int wayPointIndex = 0;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = false;
            GotoNextPoint();
        }

        private void Update()
        {
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }

        private void GotoNextPoint()
        {
            if(wayPoints.Length == 0)
            {
                return;
            }
            agent.destination = wayPoints[wayPointIndex].position;
            // iterate waypointindex
            wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
        }
    }
}
