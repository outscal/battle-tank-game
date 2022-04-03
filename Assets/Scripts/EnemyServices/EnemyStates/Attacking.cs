using UnityEngine;
using BulletServices;

namespace EnemyTankServices
{
    public class Attacking : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            tankView.activeState = EnemyState.Attacking;
        }

        private void Update()
        {
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
            if (!tankView.playerTransform)
            {
                tankView.currentState.ChangeState(tankView.patrollingState);
                return;
            }

            tankView.navAgent.SetDestination(tankView.transform.position);

            if (!IsPlayerPosition())
            {
                tankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
            }

            else if (!tankModel.b_IsFired)
            {
                tankModel.b_IsFired = true;
                FireBullet();

                await new WaitForSeconds(tankModel.fireRate);
                ResetAttack();
            }
        }

        private bool IsPlayerPosition()
        {
            Vector3 forward = tankView.turret.transform.TransformDirection(Vector3.forward);
            return Physics.Raycast(tankView.transform.position, forward, tankModel.attackRange, tankView.playerLayerMask);
        }

        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);
            Vector3 targetDir = tankView.playerTransform.position - tankView.turret.transform.position;

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