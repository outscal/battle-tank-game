using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }

    public BulletController(Vector3 direction, Vector3 spawnPos, Vector3 rotation)
    {
        bulletModel = new BulletModel();

        GameObject prefab = Resources.Load<GameObject>("Shell");
        GameObject bullet = GameObject.Instantiate<GameObject>(prefab);
        bulletView = bullet.GetComponent<BulletView>();
        bulletView.transform.position = spawnPos;
        bulletView.transform.rotation = Quaternion.Euler(rotation);
        bulletView.MoveBullet(direction, bulletModel.Force, bulletModel.DestroyTime);

    }

	
}
