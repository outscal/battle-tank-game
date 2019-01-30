using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController
{
    public PlayerModel tankModel { get; private set; }
    public PlayerView tankView { get; private set; }

    public PlayerController()
    {
        GameObject prefab = Resources.Load<GameObject>("Tank");
        GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);

        tankModel = new PlayerModel();
        tankView = tankObj.GetComponent<PlayerView>();
        InputManager.Instance.SetController(this);

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
