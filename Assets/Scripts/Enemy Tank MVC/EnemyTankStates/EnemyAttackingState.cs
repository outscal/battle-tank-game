﻿using UnityEngine;
using BulletServices;

namespace EnemyTankServices
{
    // Handles behaviour of enemy tank in attack state.
    public class EnemyAttackingState : EnemyTankBaseStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyTankView.activeState = EnemyState.Attacking;
        }

        private void Update()
        {
            // Checks for state transition conditions. 
            if (!enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange)
            {
                enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
            }
            else if (enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange)
            {
                enemyTankView.currentState.ChangeState(enemyTankView.chasingState);
            }           

            AttackPlayer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        private async void AttackPlayer()
        {
            // If player is dead, we set enemy state to patrolling state.
            if (!enemyTankView.playerTransform)
            {
                enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
                return;
            }

            enemyTankView.navAgent.SetDestination(enemyTankView.transform.position);

            if (!IsPlayerPosition())
            {
                enemyTankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
            }

            else if (!enemyTankModel.b_IsFired)
            {
                enemyTankModel.b_IsFired = true;
                FireBullet();

                await new WaitForSeconds(enemyTankModel.fireRate);
                ResetAttack();
            }
        }

        // Checks whether the enemy tank turret is facing towards player tank.
        private bool IsPlayerPosition()
        {
            Vector3 forward = enemyTankView.turret.transform.TransformDirection(Vector3.forward);

            //Cast a ray in forward direction of turret from center of tank. 
            return Physics.Raycast(enemyTankView.transform.position, forward, enemyTankModel.attackRange, enemyTankView.playerLayerMask);
        }

        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);
            Vector3 targetDir = enemyTankView.playerTransform.position - enemyTankView.turret.transform.position;

            float angle = Vector3.SignedAngle(targetDir, enemyTankView.turret.transform.forward, Vector3.up);

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

        // Fire bullet.
        private void FireBullet()
        {
            BulletService.Instance.FireBullet(enemyTankModel.bulletType, enemyTankView.fireTransform, enemyTankView.GetRandomLaunchForce());

            enemyTankView.shootingAudio.clip = enemyTankView.fireClip;
            enemyTankView.shootingAudio.Play();
        }

        private void ResetAttack()
        {
            enemyTankModel.b_IsFired = false;
        }
    }
}
