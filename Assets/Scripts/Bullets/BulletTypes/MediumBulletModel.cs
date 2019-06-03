using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.BulletTypes
{
    public class MediumBulletModel : BulletModel
    {

        public MediumBulletModel()
        {
            Damage = 10;
            Force = 10;
            DestroyTime = 1.5f;
        }
    }
}