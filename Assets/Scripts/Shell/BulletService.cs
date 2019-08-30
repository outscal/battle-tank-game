using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

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

        public void TriggerBullet(Vector3 _Initialposition, Quaternion _rotation, TankController sourceTank)
        {
            new BulletController(bulletPrefab, _Initialposition, _rotation, sourceTank);
        }
    }
}
