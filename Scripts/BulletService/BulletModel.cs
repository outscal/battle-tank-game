using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletServices
{
    public class BulletModel
    {
        public float speed { get; private set; }
        public float damage { get; private set; }

        private BulletController bulletController;

        public BulletModel(float _speed, float _damage)
        {
            speed = _speed;
            damage = _damage;

        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}