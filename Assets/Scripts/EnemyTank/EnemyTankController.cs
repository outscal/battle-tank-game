using BattleTank.PlayerTank;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    public class EnemyTankController
    {
        private NavMeshAgent navMeshAgent;
        public LayerMask PlayerLayerMask;

        //Player
        private Vector3 walkPoint;
        private bool walkPointSet;

        public EnemyTankModel EnemyTankModel { get; private set; }
        public EnemyTankView EnemyTankView { get; private set; }

        public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankView)
        {
            EnemyTankModel = _enemyTankModel;
            EnemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView);

            navMeshAgent = EnemyTankView.GetNavMeshAgent();

            EnemyTankModel.SetEnemyTankController(this);
            EnemyTankView.SetEnemyTankController(this);
        }

        public void Patroling()
        {
            if (!walkPointSet)
            {
                SearchRandomWalkPoint();
            }

            if (walkPointSet)
            {
                navMeshAgent.SetDestination(walkPoint);
            }

            //walkpoint reached
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                walkPointSet = false;
            }

            Debug.Log("walk point set status = " + walkPointSet);
        }

        private Vector3 SearchRandomWalkPoint()
        {

            float randomZ = Random.Range(-EnemyTankModel.WalkPointRange, EnemyTankModel.WalkPointRange);
            float randomX = Random.Range(-EnemyTankModel.WalkPointRange, EnemyTankModel.WalkPointRange);

            walkPoint = new Vector3(EnemyTankView.transform.position.x + randomX, EnemyTankView.transform.position.y, EnemyTankView.transform.position.z + randomZ);

            //EnemyTankView.SetWalkPoint(walkPoint);

            Debug.Log("walkpoint " + walkPoint);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(walkPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                walkPointSet = true;
            }
            Debug.Log(" Enemy tank patroling");
            return hit.position;
        }

        public void ChasePlayer()
        {
            navMeshAgent.SetDestination(TankService.Instance.TankController.TankView.transform.position);
        }
    }
}