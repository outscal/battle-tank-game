using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

namespace TankBattle.Bullet
{
    public class BulletService : GenericMonoSingleton<BulletService>
    {
        [SerializeField]
        private BulletScriptableObject bulletScriptableObject;

        public void TriggerBullet(Vector3 _initialposition, Quaternion _rotation, TankController _sourceTank)
        {
            new BulletController(bulletScriptableObject, _initialposition, _rotation, _sourceTank);
        }
    }
}
