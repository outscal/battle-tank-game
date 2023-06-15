using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    public class EnemyTankController : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Transform playerTransform;
        public LayerMask GroundLayerMask;
        public LayerMask PlayerLayerMask;

        //Player
        private Vector3 walkPoint;
        private bool walkPointSet;
        private float walkPointRange;

        //state
        private float sightRange;
        private bool playerInSightRange;

        public EnemyTankModel EnemyTankModel { get; private set; }
        public EnemyTankView EnemyTankView { get; private set; }

        public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankView)
        {
            EnemyTankModel = _enemyTankModel;
            EnemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView);

            navMeshAgent = EnemyTankView.GetMeshAgent();

            EnemyTankModel.SetTankController(this);
            EnemyTankView.SetTankController(this);
        }

        public void Patroling()
        {
            if(!walkPointSet)
            {
                SearchWalkPoint();
            }

            if(walkPointSet)
            {
                navMeshAgent.SetDestination(walkPoint);
            }

            Vector3 distanceToWalkPoint = this.transform.position - walkPoint;
            
            //walkpoint reached
            if(distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
        
        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(this.transform.position.x + randomX, this.transform.position.y + this.transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, GroundLayerMask))
            {
                walkPointSet = true;
            }
        }

        public void ChasePlayer()
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }
}