using UnityEngine;
using Tank;

namespace Enemy
{
    public class EnemyController : TankController
    {
        TankController Target;

        private void OnEnable()
        {
            SetBulletCountdown();
        }

        private void Update()
        {
            if (Target != null)
            {
                turret.transform.LookAt(Target.transform.position);
            }
            if (!bulletCooldownFlag)
            {
                ShootBullet();
            }
        }

        public void SetupEnemy(TankController target)
        {
            Target = target;
        }

        private void SetBulletCountdown()
        {

            bulletCooldownFlag = true;
            StartCoroutine(StartBulletCooldown());
        }

    }
}
