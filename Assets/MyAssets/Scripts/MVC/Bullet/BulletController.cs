using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Service;
using Bullet.Model;
using Bullet.View;

namespace Bullet.Controller
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab)
        {
            BulletModel = bulletModel;

            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);

            //BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
            BulletView.setController(this);
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
    }
}