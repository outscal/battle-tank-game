using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }

    public TankController(bool _isPlayer)
    {
        GameObject prefab = Resources.Load<GameObject>("Tank");
        GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);

        tankModel = new TankModel();
        tankView = tankObj.GetComponent<TankView>();
        InputManager inputManager = tankView.gameObject.AddComponent<InputManager>();
        inputManager.SetController(this);

    }

    public void MovePlayer(float hVal, float vVal)
    {
        tankView.MoveTank(hVal, vVal, tankModel.Speed, tankModel.RotationSpeed);
    }

    public void SpawnBullet()
    {
        BulletManager.Instance.SpawnBullet(tankView.transform.forward, tankView.BulletSpawnPos.transform.position,
                                           tankView.BulletSpawnPos.transform.eulerAngles);
    }
	
}
