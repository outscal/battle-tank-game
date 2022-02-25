using System;
using UnityEngine;

namespace Bullet
{
    public class LinearBulletController : BulletController
    {
        private Vector3 _direction;
        private Rigidbody _rigidbody;
        
        public LinearBulletController(Attack.LinearAttack attack, Scriptable_Object.Bullet.Bullet bullet) : base(attack,bullet)
        {
            _direction = attack.Direction;
            _direction = _direction.normalized;
            BulletView.transform.forward = _direction;
            _rigidbody = BulletView.GetComponent<Rigidbody>();
        }

        public override void Move()
        {
            this.BulletModel.DecreaseLifeTime(Time.fixedDeltaTime);
            if (BulletModel.LifeTime <= 0)
            {
                DestroyMe();
                return;
            }
            if(_hitSomething) return;
            if (BulletModel.LifeTime>0)
            {
                _rigidbody.velocity = _direction * BulletModel.Speed;
                return;
            }
            _rigidbody.velocity = Vector3.zero;
        }
    }
}