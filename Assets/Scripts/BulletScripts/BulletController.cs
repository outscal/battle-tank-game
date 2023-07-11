using UnityEngine;
using BattleTank.Generics;
using BattleTank.ScriptableObjects;

namespace BattleTank.Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private Rigidbody rb;

        public BulletController(BulletScriptableObject _bullet, Transform _transform, TankType tankType)
        {
            bulletView = GameObject.Instantiate<BulletView>(_bullet.bulletView, _transform.position, _transform.rotation);
            bulletModel = new BulletModel(_bullet, tankType);

            bulletView.SetBulletController(this);
            bulletModel.SetBulletController(this);

            rb = bulletView.GetRigidbody();
        }

        public void Shoot()
        {
            rb.AddForce(rb.transform.forward * bulletModel.range, ForceMode.Impulse);
        }

        public void BulletCollision(Vector3 position)
        {
            BulletService.Instance.BulletExplosion(position, bulletView);
        }

        public int GetBulletDamage()
        {
            return bulletModel.damage;
        }

        public TankType GetTankType()
        {
            return bulletModel.tankType;
        }
    }
}
