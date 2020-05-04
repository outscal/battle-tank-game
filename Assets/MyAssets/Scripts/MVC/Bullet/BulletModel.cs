using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Service;
using Bullet.Controller;
using Bullet.View;
using ScriptableObj;

namespace Bullet.Model
{
    public class BulletModel
    {
        private BulletController bulletController;
        //public BulletType type;
        public BulletModel(BulletScriptableObject bullet)
        {
            type = bullet.bulletType;
            Speed = bullet.speed;
            Damage = bullet.damage;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        public BulletType type { get; }
        public float Speed { get; }
        public float Damage { get; }
        //public BulletType BulletType { get; }
    }
}