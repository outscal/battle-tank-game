using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{

    public BulletController bulletController { get; private set; }
	
    public void SpawnBullet()
    {
        bulletController = new BulletController();
    }


}
