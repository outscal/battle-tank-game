using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletServices
{
    public class BulletModel
    {
        public float speed { get; private set; }
        public float damage { get; private set; }
        public Transform shootPoint { get; private set; }
        private BulletController bulletController;

        public BulletModel(float _speed, float _damage, Transform _shootPoint)
        {
            speed = _speed;
            damage = _damage;
            shootPoint = _shootPoint;
        }

        public void GetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}