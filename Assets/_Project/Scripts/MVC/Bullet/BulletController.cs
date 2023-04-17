using BattleTank.Enum;
using BattleTank.Services;
using UnityEngine;

namespace BattleTank.Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;
        private Vector3 bulletDirection;
        private TankID tankID;
        
        public BulletController(BulletModel _bulletModel, BulletView _bulletView, Transform tankTransform, Quaternion tankRotation, TankID _tankID)
        {
            bulletModel = _bulletModel;
            bulletView = _bulletView;
            tankID = _tankID;
            
            SpawnBullet(tankTransform, tankRotation, tankID);
        }

        private void SpawnBullet(Transform tankTransform, Quaternion tankRotation, TankID tankID)
        {
            bulletView = GameObject.Instantiate<BulletView>(bulletView, tankTransform.position, tankRotation);
            bulletView.SetBulletController(this);
            EventService.Instance.OnBulletFired(tankID);

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

        public TankID GetTankID()
        {
            return tankID;
        }
    }
}