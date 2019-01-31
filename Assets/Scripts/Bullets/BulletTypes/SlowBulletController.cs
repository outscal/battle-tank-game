using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.BulletTypes
{
    public class SlowBulletController : BulletController
    {

        protected override BulletModel getBulletModel()
        {
            return new SlowBulletModel();
        }

        protected override string BulletName()
        {
            string name = "SlowBullet";
            return name;
        }

        protected override BulletView getBulletView()
        {
            return bulletRef.GetComponent<SlowBulletView>();
        }
    }
}