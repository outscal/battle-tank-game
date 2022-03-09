using UnityEngine;

namespace Bullet
{
    public class LinearBulletController : BulletController
    {
        #region Private Data members

        private Vector3 _direction;
        private Rigidbody _rigidbody;

        #endregion

        #region Constructors

        public LinearBulletController(Attack.LinearAttack attack) : base(attack)
        {
            _direction = attack.Direction;
            _direction = _direction.normalized;
            BulletView.transform.forward = _direction;
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
            _rigidbody.velocity = _direction * BulletModel.Speed;
        }

        #endregion
    }
}