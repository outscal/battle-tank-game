using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; protected set; }
    public BulletView bulletView { get; protected set; }

    private BulletType bulletType;

    public void SpawnBullet(Vector3 direction, Vector3 spawnPos, Vector3 rotation)
    {
        bulletView.transform.position = spawnPos;
        bulletView.transform.rotation = Quaternion.Euler(rotation);
        bulletView.MoveBullet(direction, bulletModel.Force, bulletModel.DestroyTime);
    }
	
}
