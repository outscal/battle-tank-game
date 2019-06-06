using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet.BulletTypes
{
    public class SlowBulletModel : BulletModel
    {

        public SlowBulletModel()
        {
            Damage = 15;
            Force = 5;
            DestroyTime = 3f;
        }
    }
}