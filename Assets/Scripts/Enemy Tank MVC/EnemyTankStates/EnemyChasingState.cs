using UnityEngine;

namespace EnemyTankServices
{
    // Handles behaviour of enemy tank in chasing state.
    public class EnemyChasingState : EnemyTankBaseStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyTankView.activeState = EnemyState.Chasing;
        }

        private void Update()
        {
            // Checks for state transition conditions. // If condition is satisfied, transitions into desired state.
            if (!enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange) enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
            else if (enemyTankModel.b_PlayerInSightRange && enemyTankModel.b_PlayerInAttackRange) enemyTankView.currentState.ChangeState(enemyTankView.attackingState);

            ChasePlayer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        private void ChasePlayer()
        {
            if (!enemyTankView.playerTransform)
            {
                // If player is dead, we set enemy state to patrolling state.
                enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
                return;
            }

            // Set walk point as player position.
            enemyTankView.navAgent.SetDestination(enemyTankView.playerTransform.position);

            // Rotate enemy tank turret towards forward direction of enemy tank.
            if (Mathf.Abs(Vector3.SignedAngle(enemyTankView.transform.forward, enemyTankView.turret.transform.forward, Vector3.up)) > 1)
            {
                enemyTankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
            }
        }

        // Returns desired rotation of enemy tank turret.
        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);

            float angle = Vector3.SignedAngle(enemyTankView.transform.forward, enemyTankView.turret.transform.forward, Vector3.up);

            // Decides the direction of rotaion of turret. Whether to rotate from left side or right side.
            if (angle < 0)
            {
                desiredRotation = Vector3.up * enemyTankModel.turretRotationSpeed * Time.deltaTime;
            }
            else if (angle > 0)
            {
                desiredRotation = -Vector3.up * enemyTankModel.turretRotationSpeed * Time.deltaTime;
            }

            return desiredRotation;
        }
    }
}
