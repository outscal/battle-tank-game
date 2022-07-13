using UnityEngine;

namespace EnemyTankServices
{
    // Handles behaviour of enemy tank in chasing state.
    public class EnemyChasingState : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            tankView.activeState = EnemyState.Chasing;
        }

        private void Update()
        {
            // Checks for state transition conditions. // If condition is satisfied, transitions into desired state.
            if (!tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.patrollingState);
            else if (tankModel.b_PlayerInSightRange && tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.attackingState);

            ChasePlayer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        private void ChasePlayer()
        {
            if(!tankView.playerTransform)
            {
                // If player is dead, we set enemy state to patrolling state.
                tankView.currentState.ChangeState(tankView.patrollingState);
                return;
            }
            
            // We set walk point as player position.
            tankView.navAgent.SetDestination(tankView.playerTransform.position);

            // To rotate enemy tank turret towards forward direction of enemy tank.
            if( Mathf.Abs(Vector3.SignedAngle(tankView.transform.forward, tankView.turret.transform.forward, Vector3.up)) > 1)
            {
                tankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
            }
        }

        // Returns desired rotation of enemy tank turret.
        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);

            float angle = Vector3.SignedAngle(tankView.transform.forward, tankView.turret.transform.forward, Vector3.up);

            // Decides the direction of rotaion of turret. // Whether to rotate from left side or right side.
            if (angle < 0)
            {
                desiredRotation = Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
            }
            else if (angle > 0)
            {
                desiredRotation = -Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
            }

            return desiredRotation;
        }
    }
}
