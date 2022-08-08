using UnityEngine;

namespace EnemyTankServices
{
    // Handles behaviour of enemy tank in patrolling state.
    public class EnemyPatrollingState : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            tankView.activeState = EnemyState.Patrolling;        
        }

        protected override void Start()
        {
            base.Start();
            ChangeWalkPoint();
        }

        private void Update()
        {
            // Checks for state transition conditions. // If condition is satisfied, transitions into desired state.
            if (tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.chasingState);
            else if (tankModel.b_PlayerInSightRange && tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.attackingState);

            Patroling();
            ResetTurretRotation();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        // To patrol enemy tank on nav-mesh.
        private void Patroling()
        {
            // Search for walk point if enemy tank has reached to previous walk point.
            if (!tankModel.b_IsWalkPoint) SearchWalkPoint();

            // Sets destination point for nav-mesh agent.
            if (tankModel.b_IsWalkPoint)
            {
                tankView.navAgent.SetDestination(tankModel.walkPoint);
            }

            // Distance between actual tank position and walk point.
            Vector3 distanceToWalkPoint = tankView.transform.position - tankModel.walkPoint;

            // If distance is less than 1, enemy tank has reached to walk point.
            if (distanceToWalkPoint.magnitude < 1f)
            {
                tankModel.b_IsWalkPoint = false;
            }          
        }

        // Changes walk point of tank after fixed interval.
        public async void ChangeWalkPoint()
        {
            while (true)
            {
                await new WaitForSeconds(tankModel.patrolTime);
                tankModel.b_IsWalkPoint = false;
            }
        }

        // Search for walk point.
        private void SearchWalkPoint()
        {
            // Selects random walk point from given range.
            float randomZ = Random.Range(-tankModel.walkPointRange, tankModel.walkPointRange);
            float randomX = Random.Range(-tankModel.walkPointRange, tankModel.walkPointRange);

            // Setting walk point for enemy tank.
            tankModel.walkPoint = new Vector3(tankView.transform.position.x + randomX, tankView.transform.position.y, tankView.transform.position.z + randomZ);

            // To ensure walk point is on the ground.
            if (Physics.Raycast(tankModel.walkPoint, -tankView.transform.up, 2f, tankView.groundLayerMask))
            {
                tankModel.b_IsWalkPoint = true;
            }
        }

        // To reset turret rotation.
        private void ResetTurretRotation()
        {
            if (tankView.turret.transform.rotation.eulerAngles.y - tankView.transform.rotation.eulerAngles.y > 1
                || tankView.turret.transform.rotation.eulerAngles.y - tankView.transform.rotation.eulerAngles.y < -1)
            {
                Vector3 desiredRotation = Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
                tankView.turret.transform.Rotate(desiredRotation, Space.Self);
            }
        }
    }
}
