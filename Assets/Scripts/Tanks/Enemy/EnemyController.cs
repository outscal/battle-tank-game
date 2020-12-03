using UnityEngine;
using Tank;

namespace Enemy
{
    public class EnemyController : TankController
    {
        private TankController target;

        public float visionConeAngle = 45f;
        public float shootRange = 10f;
        public float movementDistance = 15f;

        public Vector3 moveDir { get; set; }
        public Vector3 distanceCheckPos { get; set; }
        public EnemyPatrollingState enemyPatrolling = new EnemyPatrollingState();
        public EnemyAttackingState enemyAttacking = new EnemyAttackingState();
        public EnemyDeadState enemyDead = new EnemyDeadState();
        private EnemyState currState;

        private void Update()
        {
            currState = currState.ExecuteState(this);
        }

        public bool CheckIfTargetIsVisible()
        {
            if (target != null)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < shootRange)
                {
                    float dotProduct = Vector3.Dot((target.transform.position - transform.position).normalized, turret.transform.forward);
                    float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
                    return angle < visionConeAngle;
                }
            }
            return false;
        }

        public void ShootBulletIfCooldown()
        {
            if (!bulletCooldownFlag)
            {
                ShootBullet();
            }
        }



        public void SetupEnemy(TankController enemyTarget)
        {
            target = enemyTarget;
            SetupEnemyMovement();
        }

        public TankController GetTarget()
        {
            return target;
        }


        private void SetupEnemyMovement()
        {
            switch (transform.eulerAngles.y)
            {
                case 270f:
                    moveDir = new Vector3(0, 0, -1);
                    break;
                case 180f:
                    moveDir = new Vector3(0, 0, 1);
                    break;
                case 0f:
                    moveDir = new Vector3(0, 0, -1);
                    break;
                case 90f:
                    moveDir = new Vector3(0, 0, 1);
                    break;
                default:
                    moveDir = Vector3.zero;
                    break;
            }
            distanceCheckPos = transform.position;
            currState = enemyPatrolling;
        }
    }
}
