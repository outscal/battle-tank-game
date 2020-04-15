using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletConroller
    {
        public BulletConroller(BulletModel bulletModel, BulletView bulletPrefab, Transform bulletParent)
        {
            BulletModel = bulletModel;
            BulletParent = bulletParent;
            BulletView = GameObject.Instantiate<BulletView>
                (bulletPrefab, bulletModel.SpawnTransform.position, bulletModel.SpawnTransform.rotation);
            BulletView.Initialize(this);

            
        }

        public BulletModel BulletModel { get; }
        public Transform BulletParent { get; }
        public BulletView BulletView { get; }


        public BulletModel GetModel()
        {
            return BulletModel;
        }
    }
}
