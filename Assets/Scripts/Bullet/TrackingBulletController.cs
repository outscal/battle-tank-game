using UnityEngine;

namespace Bullet
{
    public class TrackingBulletController: BulletController
    {
        private Transform _target;
        private Rigidbody _rigidbody;
        
        public TrackingBulletController(Attack.TrackingAttack attack) : base(attack)
        {
            _target = attack.Target.transform;
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
            if (BulletModel.LifeTime>0 && _target!=null)
            {
                Vector3 direction = (_target.position - BulletView.transform.position).normalized;
                _rigidbody.velocity = direction * BulletModel.Speed;
                BulletView.transform.forward = direction;

            }
        }
    }
}