using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

namespace TankBattle.Bullet
{
    public class BulletService : GenericMonoSingleton<BulletService>
    {
        public BulletScriptableObject bulletScriptableObject;

        void Start()
        {

        }

        void Update()
        {

        }

        public void TriggerBullet(Vector3 _Initialposition, Quaternion _rotation, TankController sourceTank)
        {
            new BulletController(bulletScriptableObject, _Initialposition, _rotation, sourceTank);
        }
    }
}
