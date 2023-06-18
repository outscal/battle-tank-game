using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent;

        //state
        private bool playerInSightRange;

        public EnemyTankController EnemyTankController { get; private set; }

        public void SetEnemyTankController(EnemyTankController enemyTankController)
        {
            EnemyTankController = enemyTankController;
        }

        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, EnemyTankController.EnemyTankModel.sightRange, EnemyTankController.EnemyTankModel.PlayerLayerMask);

            if (!playerInSightRange)
            {
                EnemyTankController.Patroling();
            }

            if (playerInSightRange)
            {
                EnemyTankController.ChasePlayer();
            }
        }

        public NavMeshAgent GetNavMeshAgent()
        {
            return NavMeshAgent;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, EnemyTankController.EnemyTankModel.sightRange);
        }
    }
}