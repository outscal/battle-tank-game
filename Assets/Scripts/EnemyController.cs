using UnityEngine;
using Tank;

namespace Enemy
{
    public class EnemyController : TankController
    {
        TankController Target;
        float bulletCooldownTime = 8f;
        float bulletCooldownTimer = 0;

        private void Update()
        {
            if (Target != null)
            {
                turret.transform.LookAt(Target.transform.position);
            }
            bulletCooldownTimer += Time.deltaTime;
            if (bulletCooldownTimer >= bulletCooldownTime)
            {
                ShootBullet();
                bulletCooldownTimer = 0f;
            }

        }

        public void SetupEnemy(TankController target)
        {
            Target = target;
        }

    }
}
