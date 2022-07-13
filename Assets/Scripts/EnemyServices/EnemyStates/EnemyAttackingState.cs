using UnityEngine;
using BulletServices;

namespace EnemyTankServices
{
    // Handles behaviour of enemy tank in attack state.
    public class EnemyAttackingState : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            tankView.activeState = EnemyState.Attacking; 
        }

        private void Update()
        {
            // Checks for state transition conditions. // If condition is satisfied, transitions into desired state.
            if (!tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.patrollingState);
            else if (tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.chasingState);

            AttackPlayer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        private async void AttackPlayer()
        {
            // If player is dead, we set enemy state to patrolling state.
            if (!tankView.playerTransform)
            {
                tankView.currentState.ChangeState(tankView.patrollingState);
                return;
            }

            // We set walk point to current position so that enemy should not change its position in attack state. 
            tankView.navAgent.SetDestination(tankView.transform.position);

            // If enemy tank turret is not facing towards player, we rotate turret towards player.
            if (!IsPlayerPosition())
            {
                tankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
            }

            // If turret is facing towards player, fire bullet.
            else if (!tankModel.b_IsFired)
            {
                tankModel.b_IsFired = true;
                FireBullet();

                // Enemy tank fires bullet after certain interval of time. // FireRate.
                await new WaitForSeconds(tankModel.fireRate);
                ResetAttack();
            }
        }

        // Checks whether the enemy tank turret is facing towards player tank.
        private bool IsPlayerPosition()
        {
            // Forward direction of enemy tank turret.
            Vector3 forward = tankView.turret.transform.TransformDirection(Vector3.forward);

            // We cast a ray in forward direction of turret from center of tank. 
            return Physics.Raycast(tankView.transform.position, forward, tankModel.attackRange, tankView.playerLayerMask);
        }

        // Returns desired rotation of enemy tank turret.
        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);
            Vector3 targetDir = tankView.playerTransform.position - tankView.turret.transform.position;

            // Decides the direction of rotaion of turret. // Whether to rotate from left side or right side.
            float angle = Vector3.SignedAngle(targetDir, tankView.turret.transform.forward, Vector3.up);

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

        // To fire bullet.
        private void FireBullet()
        {
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankView.GetRandomLaunchForce());

            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();
        }

        private void ResetAttack()
        {
            tankModel.b_IsFired = false;
        }
    }
}
