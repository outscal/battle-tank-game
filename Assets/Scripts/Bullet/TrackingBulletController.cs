using UnityEngine;

namespace Bullet
{
    public class TrackingBulletController: BulletController
    {
        private Transform _target;
        private Rigidbody _rigidbody;
        
        public TrackingBulletController(Attack.TrackingAttack attack, Scriptable_Object.Bullet.Bullet bullet) : base(attack,bullet)
        {
            _target = attack.Target.transform;
            _rigidbody = BulletView.GetComponent<Rigidbody>();
        }

        public override void Move()
        {
            if (BulletModel.LifeTime>0)
            {
                Vector3 direction = (_target.position - BulletView.transform.position).normalized;
                _rigidbody.velocity = direction * BulletModel.Speed;
                BulletView.transform.forward = direction;
                BulletModel.DecreaseLifeTime(Time.fixedTime);
                return;
            }
            _rigidbody.velocity = Vector3.zero;
        }
    }
}