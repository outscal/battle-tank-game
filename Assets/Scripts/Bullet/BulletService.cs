using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankGame.Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {

        public BulletScriptableObjectList bulletList;
        public BulletView bulletView;
        private Vector3 spawnPos;

        protected override void Awake()
        {
            base.Awake();
        }

        public void spawnBullet(Transform bulletSpawner, float bulletDamage)
        {
            BulletModel bulletModel = new BulletModel(bulletList.bulletScriptableObject[0]);
            BulletController bullet = new BulletController(bulletModel, bulletView, bulletSpawner, bulletDamage);
        }
    }
}