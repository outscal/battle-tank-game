using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletModel : BulletModel {

    public FastBulletModel()
    {
        Damage = 5;
        Force = 20;
        DestroyTime = 1f;
    }
}
