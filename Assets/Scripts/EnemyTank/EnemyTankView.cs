using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public Transform PlayerTransform;
        public LayerMask GroundLayerMask;
        public LayerMask PlayerLayerMask;

        //Patrolling
        public Vector3 walkPoint;
        public bool walkPointSet;
        public float walkPointRange;

        //state
        public float sightRange;
        public bool playerInSightRange;

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
            playerInSightRange = Physics.CheckSphere(this.transform.position, sightRange, PlayerLayerMask);

            if(!playerInSightRange )
            {
                EnemyTankController.Patroling();
            }

            if(playerInSightRange )
            {
                EnemyTankController.ChasePlayer();
            }
        }

        public NavMeshAgent GetMeshAgent()
        {
            return navMeshAgent;
        }
    }
}