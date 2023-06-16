using BattleTank.PlayerTank;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    public class EnemyTankController
    {
        private NavMeshAgent navMeshAgent;
        public LayerMask GroundLayerMask;
        public LayerMask PlayerLayerMask;

        //Player
        private Vector3 walkPoint;
        private bool walkPointSet;
        private float walkPointRange;

        public EnemyTankModel EnemyTankModel { get; private set; }
        public EnemyTankView EnemyTankView { get; private set; }

        public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankView)
        {
            EnemyTankModel = _enemyTankModel;
            EnemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView);

            navMeshAgent = EnemyTankView.GetNavMeshAgent();

            EnemyTankModel.SetTankController(this);
            EnemyTankView.SetTankController(this);
        }

        public void Patroling()
        {
            if(!walkPointSet)
            {
                SearchWalkPoint();
                Debug.Log(" Enemy tank patroling");
            }

            if(walkPointSet)
            {
                navMeshAgent.SetDestination(EnemyTankView.GetWalkPoint());
            }

            Vector3 distanceToWalkPoint = EnemyTankView.transform.position - EnemyTankView.GetWalkPoint();
            
            //walkpoint reached
            if(distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
         
        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-EnemyTankView.GetWalkPointRange(), EnemyTankView.GetWalkPointRange());
            float randomX = Random.Range(-EnemyTankView.GetWalkPointRange(), EnemyTankView.GetWalkPointRange());

            walkPoint = new Vector3(EnemyTankView.transform.position.x + randomX, EnemyTankView.transform.position.y, EnemyTankView.transform.position.z + randomZ);

            EnemyTankView.SetWalkPoint(walkPoint); 

            Debug.Log("walkpoint " + walkPoint);

            if (Physics.Raycast(EnemyTankView.GetWalkPoint(), -EnemyTankView.transform.up, 2f, EnemyTankView.GroundLayerMask))
            {
                walkPointSet = true;
            }
        }

        public void ChasePlayer()
        {
            navMeshAgent.SetDestination(TankService.Instance.TankController.TankView.transform.position);
        }
    }
}