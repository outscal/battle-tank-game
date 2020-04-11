using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletConroller
    {
        public BulletConroller(BulletModel bulletModel, BulletView bulletPrefab)
        {
            BulletModel = bulletModel;

            BulletView = GameObject.Instantiate<BulletView>
                (bulletPrefab, bulletModel.SpawnTransform.position, bulletModel.SpawnTransform.rotation);
            BulletView.Initialize(this);

            
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }


        public BulletModel GetModel()
        {
            return BulletModel;
        }


        public void MoveBullet(Rigidbody bulletBody, float launchForce)
        {
            bulletBody.velocity = launchForce * BulletModel.SpawnTransform.forward;
        }
    }
}
