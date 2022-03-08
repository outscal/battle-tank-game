using UnityEngine;

namespace Bullet
{
    public class TrackingBulletController: BulletController
    {
        #region Private Data members

        private Transform _target;
        private Rigidbody _rigidbody;

        #endregion

        #region Constructors

        public TrackingBulletController(Attack.TrackingAttack attack) : base(attack)
        {
            _target = attack.Target.transform;
            _rigidbody = BulletView.GetComponent<Rigidbody>();
        }

        #endregion

        #region Public Functions

        public override void Move()
        {
            this.BulletModel.DecreaseLifeTime(Time.fixedDeltaTime);
            if (BulletModel.LifeTime <= 0)
            {
                DestroyMe();
                return;
            }
            if(hitSomething) return;
            if (_target)
            {
                Transform bullet = BulletView.transform;
                Vector3 direction = (_target.position - bullet.position).normalized;
                _rigidbody.velocity = direction * BulletModel.Speed;
                bullet.forward = direction;

            }
        }

        #endregion
    }
}