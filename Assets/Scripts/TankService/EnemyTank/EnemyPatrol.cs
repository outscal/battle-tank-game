using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

namespace TankBattle.Tank.EnemyTank
{
    public class EnemyPatrol : MonoBehaviour
    {
        //[SerializeField] private Transform[] wayPoints;
        [SerializeField] private float radiusRange = 10f;

        private Transform centerPoint; // try without first

        private NavMeshAgent agent;
        private int wayPointIndex = 0;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = false;
            //GotoNextPoint();
        }

        private void Update()
        {
            //if(!agent.pathPending && agent.remainingDistance < 0.5f)
            //{
            //    GotoNextPoint();
            //}

            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(agent.transform.position, radiusRange, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
        }

        bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for(int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
                    //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
                {
                    //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
                    //or add a for loop like in the documentation
                    result = hit.position;
                    return true;
                }
            }

            result = Vector3.zero;
            return false;
        }

        //private void GotoNextPoint()
        //{
        //    if(wayPoints.Length == 0)
        //    {
        //        return;
        //    }
        //    agent.destination = wayPoints[wayPointIndex].position;
        //    // iterate waypointindex
        //    wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
        //}
    }
}
