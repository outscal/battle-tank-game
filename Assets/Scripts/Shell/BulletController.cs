using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Bullet
{
    public class BulletController
    {
        private BulletView bulletView;
        private BulletModel bulletModel;

        public BulletController(BulletView _prefab, Vector3 _position, Quaternion _rotation)
        {
            bulletModel = new BulletModel();
            bulletView = GameObject.Instantiate<BulletView>(_prefab, _position, _rotation);
        }

    }
}
