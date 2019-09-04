using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Bullet
{
    public class BulletModel
    {
        public int damage = 10;
        public BulletView bulletPrefab;
        public BulletModel(BulletScriptableObject _bulletScriptableObject)
        {
            damage = _bulletScriptableObject.damage;
            bulletPrefab = _bulletScriptableObject.bulletPrefab;
        }

    }
}
