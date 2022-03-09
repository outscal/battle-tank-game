using Tank;
using Tank.Interfaces;
using UnityEngine;

namespace Bullet
{
    public abstract class BulletController
    {
        #region Private Data members

        private BulletView _bulletView;
        private BulletModel _bulletModel;
        protected bool hitSomething;

        #endregion

        #region Public Data members

        public BulletView BulletView => _bulletView;
        public BulletModel BulletModel => _bulletModel;

        public bool HitSomething => hitSomething;

        #endregion

        #region Constructors

        protected BulletController(Attack.Attack attack)
        {
            _bulletModel = new BulletModel(attack.Bullet.BulletModel);
            _bulletModel.SetDamage(attack.Damage);
            _bulletModel.SetTankType(attack.TankType);
            _bulletView = Object.Instantiate(attack.Bullet.BulletView,attack.Position,Quaternion.identity);
            _bulletView.BulletController = this;
            hitSomething = false;
        }

        #endregion

        #region Protected Functions

        protected void DestroyMe()
        {
            Object.Destroy(_bulletView.gameObject);
            BulletService.Instance.Destroy(this);
        }

        #endregion

        #region Public Functions

        public abstract void Move();

        public void HitBy(Collision other)
        {
            hitSomething = true;
            BulletService.Instance.MakeExplosion(other);
            if (other.gameObject.GetComponent<IDamageable>() != null)
            {
                if (other.gameObject.GetComponent<TankView>().TankController.TankModel.TankType!=_bulletModel.TankType)
                {
                    other.gameObject.GetComponent<IDamageable>().DamageReceived(_bulletModel.Damage);
                    DestroyMe();
                }
            }
        }

        #endregion
    }
}