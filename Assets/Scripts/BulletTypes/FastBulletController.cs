using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletController : BulletController
{

    protected override BulletModel getBulletModel()
    {
        return new FastBulletModel();
    }

    protected override string BulletName()
    {
        string name = "FastBullet";
        return name;
    }

    protected override BulletView getBulletView()
    {
        return bulletRef.GetComponent<FastBulletView>();
    }
}
