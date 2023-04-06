using UnityEngine;

namespace BattleTank.Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private Vector3 bulletDirection;
        
        public BulletController(BulletModel _bulletModel, BulletView _bulletView, Transform tankTransform, Quaternion tankRotation)
        {
            bulletModel = _bulletModel;
            bulletView = _bulletView;
            
            SpawnBullet(tankTransform, tankRotation);
        }

        private void SpawnBullet(Transform tankTransform, Quaternion tankRotation)
        {
            bulletView = GameObject.Instantiate<BulletView>(bulletView, tankTransform.position, tankRotation);
            bulletView.SetBulletController(this);

            FireBullet();
        }

        private void FireBullet()
        {
            bulletDirection = bulletView.transform.forward;
            bulletView.GetRigidBody().AddForce(bulletDirection * bulletModel.Speed * Time.deltaTime, ForceMode.Impulse);
        }

        public float GetDamageValue()
        {
            return bulletModel.Damage;
        }
    }
}