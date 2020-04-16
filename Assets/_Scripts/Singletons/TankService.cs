using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;
    public BulletService BulletService;

    private void Start()
    {
        CreateNewTank();
    }

    private TankController CreateNewTank()
    {
        TankModel tankModel = new TankModel(15f);
        TankController tankController = new TankController(tankModel, tankView);
        tankController.SetTankService(this);
        return tankController;
    }

    public void FireBullet(Vector3 position, Vector3 tankRotation)
    {
        BulletService.CreateNewBullet(position, tankRotation);
    }
}
