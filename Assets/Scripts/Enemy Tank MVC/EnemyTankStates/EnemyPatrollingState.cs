using UnityEngine;

namespace EnemyTankServices
{
    /// <summary>
    /// This class is responsible for handling the Tank Patrolling logic when in Patrolling State.
    /// </summary>
    public class EnemyPatrollingState : EnemyTankBaseStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyTankView.activeState = EnemyState.Patrolling;
        }

        protected override void Start()
        {
            base.Start();
            ChangePatrolPoint();
        }

        private void Update()
        {
            // Checks for state transition conditions. 
            if (enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange) enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);

            Patroling();
        } 

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        // To patrol enemy tank on nav-mesh.
        public void Patroling()
        {
            // Search for patrol point if enemy tank has reached to previous patrol point.
            if (!enemyTankModel.b_IsPatrolPoint)
                SearchPatrolPoint();

            // Sets destination point for nav-mesh agent.
            if (enemyTankModel.b_IsPatrolPoint)
            {
                enemyTankView.navAgent.SetDestination(enemyTankModel.patrolPoint);
            }

            // Distance between actual tank position and patrol point.
            Vector3 distanceToPatrolPoint = enemyTankView.transform.position - enemyTankModel.patrolPoint;

            // If distance is less than 1, enemy tank has reached to patrol point.
            if (distanceToPatrolPoint.magnitude < 1f)
            {
                enemyTankModel.b_IsPatrolPoint = false;
            }
        }

        // Changes walk point of tank after fixed interval.
        public async void ChangePatrolPoint()
        {
            while (true)
            {
                await new WaitForSeconds(enemyTankModel.patrolTime);
                enemyTankModel.b_IsPatrolPoint = false;
            }
        }

        // Search for patrol point.
        private void SearchPatrolPoint()
        {
            // Selects random patrol point from given range.
            float randomX = Random.Range(-enemyTankModel.patrolPointRange, enemyTankModel.patrolPointRange);
            float randomZ = Random.Range(-enemyTankModel.patrolPointRange, enemyTankModel.patrolPointRange);

            // Setting patrol point for enemy tank.
            enemyTankModel.patrolPoint = new Vector3(enemyTankView.transform.position.x + randomX, enemyTankView.transform.position.y, enemyTankView.transform.position.z + randomZ);

            // To ensure patrol point is on the ground.
            if (Physics.Raycast(enemyTankModel.patrolPoint, -enemyTankView.transform.up, 2f, enemyTankView.groundLayerMask))
            {
                enemyTankModel.b_IsPatrolPoint = true;
            }
        }
    }
}
