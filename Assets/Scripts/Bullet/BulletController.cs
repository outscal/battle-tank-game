using UnityEngine;

namespace Bullet
{
    public abstract class BulletController
    {
        private BulletView _bulletView;
        protected BulletModel _bulletModel;

        public BulletView BulletView => _bulletView;
        public BulletModel BulletModel => _bulletModel;

        public BulletController(Attack.Attack attack, Scriptable_Object.Bullet.Bullet bullet)
        {
            _bulletModel = new BulletModel(bullet.BulletModel);
            _bulletView = GameObject.Instantiate<BulletView>(bullet.BulletView,attack.Position,Quaternion.identity);
            _bulletView.BulletController = this;
        }
        public abstract void Move();
    }
}