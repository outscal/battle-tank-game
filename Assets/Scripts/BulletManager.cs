using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{

    public BulletController bulletController { get; private set; }
	

    public void SpawnBullet(Vector3 direction, Vector3 spawnPos, Vector3 rotation)
    {
        bulletController = new BulletController(direction, spawnPos, rotation);
    }


}
