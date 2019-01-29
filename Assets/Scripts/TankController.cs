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
        tankModel.isPlayer = _isPlayer;
        tankView = tankObj.GetComponent<TankView>();

        tankView.controller = this;
    }

    public void MovePlayer(float hVal, float vVal)
    {
        tankView.Move(hVal, vVal, tankModel.speed, tankModel.rotationSpeed);
    }
	
}
