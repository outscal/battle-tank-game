using Attack;
using UnityEngine;

namespace Bullet
{
    public class BulletService : SingletonMB<BulletService>
    {
        [SerializeField] private Scriptable_Object.Bullet.BulletList bullets;

        public BulletController CreateBullet(Attack.Attack attack)
        {
            BulletController newBulletController = null;
            int index = (int) attack.BulletType-1;
            switch(attack.BulletType)
            {
                case BulletType.LinearFast:
                case BulletType.LinearSlow:
                    newBulletController = new LinearBulletController((LinearAttack)attack, bullets.List[index]);
                    break;
                case BulletType.TrackingFast:
                case BulletType.TrackingSlow:
                    newBulletController = new TrackingBulletController((TrackingAttack)attack, bullets.List[index]);
                    break;
            }

            return newBulletController;
        }

        public void Destroy(BulletController bulletController)
        {
            bulletController = null;
        }
    }
}