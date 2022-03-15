using UnityEngine;

namespace EnemyTankServices
{
    public class Chasing : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            tankView.activeState = EnemyState.Chasing;
        }

        private void Update()
        {
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
            if (!tankView.playerTransform)
            {
                tankView.currentState.ChangeState(tankView.patrollingState);
                return;
            }

            tankView.navAgent.SetDestination(tankView.playerTransform.position);

            if (Mathf.Abs(Vector3.SignedAngle(tankView.transform.forward, tankView.turret.transform.forward, Vector3.up)) > 1)
            {
                tankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
            }
        }

        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);

            float angle = Vector3.SignedAngle(tankView.transform.forward, tankView.turret.transform.forward, Vector3.up);

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
