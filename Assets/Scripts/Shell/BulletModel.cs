using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Bullet
{
    public class BulletModel
    {
        private int damage;
        public int Damage{get{return damage; }}
        private BulletView bulletPrefab;
        public BulletView BulletPrefab{get{return bulletPrefab; }}
        public BulletModel(BulletScriptableObject _bulletScriptableObject)
        {
            damage = _bulletScriptableObject.damage;
            bulletPrefab = _bulletScriptableObject.bulletPrefab;
        }

    }
}
