using UnityEngine;
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
            Debug.Log("Attacking is enabled");
        }

        private void Update()
        {
            // Checks for state transition conditions. // If condition is satisfied, transitions into desired state.
            if (!enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange) enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
            else if (enemyTankModel.b_PlayerInSightRange && !enemyTankModel.b_PlayerInAttackRange) enemyTankView.currentState.ChangeState(enemyTankView.chasingState);
            Debug.Log("Enemy Tank Phase :- " + enemyTankView.currentState);

            AttackPlayer();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Attacking is disabled");
        }

        private async void AttackPlayer()
        {
            // If player is dead, we set enemy state to patrolling state.
            if (!enemyTankView.playerTransform)
            {
                Debug.Log("Player is died, going to patrol again");
                enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
                return;
            }

            // We set walk point to current position so that enemy should not change its position in attack state. 
            enemyTankView.navAgent.SetDestination(enemyTankView.transform.position);
            Debug.Log("Not changing his position");

            // If enemy tank turret is not facing towards player, we rotate turret towards player.
            if (!IsPlayerPosition())
            {
                enemyTankView.turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
                Debug.Log("Rotating turrent towards the player");
            }

            // If turret is facing towards player, fire bullet.
            else if (!enemyTankModel.b_IsFired)
            {
                enemyTankModel.b_IsFired = true;
                FireBullet();

                // Enemy tank fires bullet after certain interval of time. // FireRate.
                await new WaitForSeconds(enemyTankModel.fireRate);
                ResetAttack();
            }
        }

        // Checks whether the enemy tank turret is facing towards player tank.
        private bool IsPlayerPosition()
        {
            // Forward direction of enemy tank turret.
            Vector3 forward = enemyTankView.turret.transform.TransformDirection(Vector3.forward);

            // We cast a ray in forward direction of turret from center of tank. 
            return Physics.Raycast(enemyTankView.transform.position, forward, enemyTankModel.attackRange, enemyTankView.playerLayerMask);
        }

        // Returns desired rotation of enemy tank turret.
        private Vector3 GetRequiredTurretRotation()
        {
            Vector3 desiredRotation = new Vector3(0, 0, 0);
            Vector3 targetDir = enemyTankView.playerTransform.position - enemyTankView.turret.transform.position;

            // Decides the direction of rotaion of turret. // Whether to rotate from left side or right side.
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

        // To fire bullet.
        private void FireBullet()
        {
            Debug.Log("Firing the bullets");
            BulletService.Instance.FireBullet(enemyTankModel.bulletType, enemyTankView.fireTransform, enemyTankView.GetRandomLaunchForce());

        }

        private void ResetAttack()
        {
            enemyTankModel.b_IsFired = false;
        }
    }
}
