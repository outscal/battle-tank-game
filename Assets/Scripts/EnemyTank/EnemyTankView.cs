using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public LayerMask GroundLayerMask;
        public LayerMask PlayerLayerMask;

        //state
        public float sightRange;
        public bool playerInSightRange;
        public float walkPointRange;
        public Vector3 WalkPoint;

        public EnemyTankController EnemyTankController { get; private set; }

        public void SetTankController(EnemyTankController enemyTankController)
        {
            EnemyTankController = enemyTankController;
        }

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerLayerMask);

            if(!playerInSightRange )
            {
                EnemyTankController.Patroling();
            }

            if(playerInSightRange )
            {
                EnemyTankController.ChasePlayer();
            }
        }

        public NavMeshAgent GetNavMeshAgent()
        {
            return navMeshAgent;
        }

        public float GetWalkPointRange()
        {
            return walkPointRange;
        }

        public Vector3 GetWalkPoint()
        {
            return WalkPoint;
        }

        public void SetWalkPoint(Vector3 value)
        {
            WalkPoint = value;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}