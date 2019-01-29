using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBulletModel : BulletModel {

    public SlowBulletModel()
    {
        Damage = 15;
        Force = 5;
        DestroyTime = 3f;
    }
}
