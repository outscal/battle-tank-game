using UnityEngine;

namespace BattleTank.BulletShooting
{
    public class BulletController
    {
        public BulletModel BulletModel { get; private set; }
        public BulletView BulletView { get; private set; }

        public BulletController(BulletModel _bulletModel, BulletView _bulletView)
        {
            BulletModel = _bulletModel;
            BulletView = GameObject.Instantiate<BulletView>(_bulletView);

            BulletModel.SetBulletController(this);
            BulletView.SetBulletController(this);
        }
    }
}