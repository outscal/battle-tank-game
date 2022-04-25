using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Tank;

public class ServicePoolTank : ServicePool<TankController>
{
    private TankModel tankModel;
    private TankView tankPrefab;
    public TankController GetTank(TankModel tankModel, TankView tankPrefab)
    {
        this.tankModel = tankModel;
        this.tankPrefab = tankPrefab;
        return GetItem();
    }
    protected override TankController CreateItem()
    {
        TankController tankController = new TankController(tankModel, tankPrefab);
        return tankController;
    }
}