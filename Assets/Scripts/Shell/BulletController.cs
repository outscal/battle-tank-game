using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

namespace TankBattle.Bullet
{
    public class BulletController
    {
        private  BulletView bulletView;
        private  BulletModel bulletModel;
        public readonly TankController sourceTank;

        public BulletController(BulletScriptableObject _bulletScriptableObject, Vector3 _position, Quaternion _rotation, TankController _sourceTank)
        {
            bulletModel = new BulletModel(_bulletScriptableObject);
            bulletView = GameObject.Instantiate<BulletView>(bulletModel.BulletPrefab, _position, _rotation);
            bulletView.SetController(this);
            sourceTank = _sourceTank;
        }

        public void DestroyBullet()
        {
            bulletModel = null;
            bulletView.DestroyBulletView();
            bulletView = null;
        }

        public int GetBulletDamagePower()
        {
            return bulletModel.Damage;
        }
    }
}
