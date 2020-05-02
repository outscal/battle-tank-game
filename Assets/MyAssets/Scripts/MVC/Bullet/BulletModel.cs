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
        public BulletType type;
        public BulletModel(BulletScriptableObject bullet)
        {
            speed = bullet.speed;
            damage = bullet.damage;
            type = bullet.bulletType;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        public float speed { get; }
        public float damage { get; }
        //public BulletType BulletType { get; }
    }
}