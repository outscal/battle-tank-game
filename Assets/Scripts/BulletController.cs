using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }

    public BulletController()
    {
        bulletModel = new BulletModel();

        GameObject prefab = Resources.Load<GameObject>("Shell");
        GameObject bullet = GameObject.Instantiate<GameObject>(prefab);
        bulletView = bullet.GetComponent<BulletView>();

    }

    public void SetBulletValues(Vector3 bulletSpawnPos)
    {
        bulletView.gameObject.transform.position = bulletSpawnPos;
    }
	
}
