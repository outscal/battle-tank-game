using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBulletController : BulletController 
{
    public MediumBulletController()
    {
        bulletModel = new MediumBulletModel();
        GameObject prefab = Resources.Load<GameObject>("MediumBullet");
        GameObject bullet = GameObject.Instantiate<GameObject>(prefab);
        bulletView = bullet.GetComponent<MediumBulletView>();
    }
	
}
