using System.Collections;
using Tank;
using UnityEngine;

namespace Bullet
{
    public abstract class BulletController
    {
        private BulletView _bulletView;
        private BulletModel _bulletModel;
        protected bool _hitSomething;

        public BulletView BulletView => _bulletView;
        public BulletModel BulletModel => _bulletModel;

        public BulletController(Attack.Attack attack)
        {
            _bulletModel = new BulletModel(attack.Bullet.BulletModel);
            _bulletModel.SetDamage(attack.Damage);
            _bulletModel.SetTankType(attack.TankType);
            _bulletView = GameObject.Instantiate(attack.Bullet.BulletView,attack.Position,Quaternion.identity);
            _bulletView.BulletController = this;
            _hitSomething = false;
        }

        public abstract void Move();

        public void HitBy(Collision other)
        {
            _hitSomething = true;
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
        

        protected void DestroyMe()
        {
            GameObject.Destroy(_bulletView.gameObject);
            BulletService.Instance.Destroy(this);
        }
    }
}