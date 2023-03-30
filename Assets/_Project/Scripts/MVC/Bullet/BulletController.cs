using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private Vector3 bulletDirection;
        
        public BulletController(BulletModel _bulletModel, BulletView _bulletView, Transform transform, Quaternion quaternion)
        {
            bulletModel = _bulletModel;
            bulletView = _bulletView;
            
            SpawnBullet(transform, quaternion);
        }

        private void SpawnBullet(Transform transform, Quaternion quaternion)
        {
            bulletView = GameObject.Instantiate<BulletView>(bulletView, transform.position, quaternion);
            bulletView.SetBulletController(this);

            FireBullet();
        }

        private void FireBullet()
        {
            bulletDirection = bulletView.transform.forward;
            bulletView.GetRigidBody().AddForce(bulletDirection * bulletModel.speed * Time.deltaTime, ForceMode.Impulse);
        }

        public float GetDamage()
        {
            return bulletModel.damage;
        }
    }
}