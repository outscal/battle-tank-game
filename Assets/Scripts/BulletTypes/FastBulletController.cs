using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletController : BulletController
{

    public FastBulletController()
    {
        bulletModel = new FastBulletModel();
        GameObject prefab = Resources.Load<GameObject>("FastBullet");
        GameObject bullet = GameObject.Instantiate<GameObject>(prefab);
        bulletView = bullet.GetComponent<FastBulletView>();
    }

}
