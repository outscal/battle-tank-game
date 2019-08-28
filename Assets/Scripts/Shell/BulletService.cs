using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Bullet
{
    public class BulletService : GenericMonoSingleton<BulletService>
    {
        public BulletView bulletPrefab;

        void Start()
        {

        }

        void Update()
        {

        }

        public void TriggerBullet(Vector3 _Initialposition, Quaternion _rotation)
        {
            new BulletController(bulletPrefab, _Initialposition, _rotation);
        }
    }
}
