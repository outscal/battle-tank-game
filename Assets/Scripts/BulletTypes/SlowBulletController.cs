using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBulletController : BulletController {

    public SlowBulletController()
    {
        bulletModel = new SlowBulletModel();
        GameObject prefab = Resources.Load<GameObject>("SlowBullet");
        GameObject bullet = GameObject.Instantiate<GameObject>(prefab);
        bulletView = bullet.GetComponent<SlowBulletView>();
    }
}
