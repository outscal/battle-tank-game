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

        public BulletController(Attack.Attack attack, Scriptable_Object.Bullet.Bullet bullet)
        {
            _bulletModel = new BulletModel(bullet.BulletModel);
            _bulletModel.SetDamage(attack.Damage);
            _bulletView = GameObject.Instantiate(bullet.BulletView,attack.Position,Quaternion.identity);
            _bulletView.BulletController = this;
            _hitSomething = false;
        }

        public abstract void Move();

        public void HitBy(Collision other)
        {
            _hitSomething = true;
            if(other.gameObject.GetComponent<TankView>()) DestroyMe();
        }

        protected void DestroyMe()
        {
            GameObject.Destroy(_bulletView.gameObject);
            BulletService.Instance.Destroy(this);
        }
    }
}