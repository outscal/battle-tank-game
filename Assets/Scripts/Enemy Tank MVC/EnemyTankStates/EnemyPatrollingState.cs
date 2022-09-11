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
            ChangeWalkPoint();
        }

        private void Update()
        {
            // Checks for state transition conditions. 
            if (enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange)
            {
                enemyTankView.currentState.ChangeState(enemyTankView.chasingState);
            }
            else if (enemyTankModel.b_PlayerInSightRange && enemyTankModel.b_PlayerInAttackRange)
            {
                enemyTankView.currentState.ChangeState(enemyTankView.attackingState);
            }


            Patroling();
            ResetTurretRotation();
        } 

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        // Enemy tank patroling on Nav-mesh.
        public void Patroling()
        {
            // Search for patrol point if enemy tank has reached to previous patrol point.
            if (!enemyTankModel.b_IsPatrolPoint)
                SearchWalkPoint();

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
        public async void ChangeWalkPoint()
        {
            while (true)
            {
                await new WaitForSeconds(enemyTankModel.patrolTime);
                enemyTankModel.b_IsPatrolPoint = false;
            }
        }

        // Search for patrol point.
        private void SearchWalkPoint()
        {
            // Selects random patrol point from given range.
            float randomX = Random.Range(-enemyTankModel.walkPointRange, enemyTankModel.walkPointRange);
            float randomZ = Random.Range(-enemyTankModel.walkPointRange, enemyTankModel.walkPointRange);

            // Setting patrol point for enemy tank.
            enemyTankModel.patrolPoint = new Vector3(enemyTankView.transform.position.x + randomX, enemyTankView.transform.position.y, enemyTankView.transform.position.z + randomZ);

            // To ensure patrol point is on the ground.
            if (Physics.Raycast(enemyTankModel.patrolPoint, -enemyTankView.transform.up, 2f, enemyTankView.groundLayerMask))
            {
                enemyTankModel.b_IsPatrolPoint = true;
            }
        }

        // To reset turret rotation.
        private void ResetTurretRotation()
        {
            if (enemyTankView.turret.transform.rotation.eulerAngles.y - enemyTankView.transform.rotation.eulerAngles.y > 1
                || enemyTankView.turret.transform.rotation.eulerAngles.y - enemyTankView.transform.rotation.eulerAngles.y < -1)
            {
                Vector3 desiredRotation = Vector3.up * enemyTankModel.turretRotationSpeed * Time.deltaTime;
                enemyTankView.turret.transform.Rotate(desiredRotation, Space.Self);
            }
        }
    }
}
