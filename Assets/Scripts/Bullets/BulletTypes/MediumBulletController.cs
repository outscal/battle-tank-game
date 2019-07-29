using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.BulletTypes
{
    public class MediumBulletController : BulletController
    {
        protected override BulletModel getBulletModel()
        {
            return new MediumBulletModel();
        }

        protected override string BulletName()
        {
            string name = "MediumBullet";
            return name;
        }

        protected override BulletView getBulletView()
        {
            return bulletRef.GetComponent<MediumBulletView>();
        }
    }
}