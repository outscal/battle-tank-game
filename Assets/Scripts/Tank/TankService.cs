using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : SingletonMB<TankService>
{
    [SerializeField] private TankView _tankView;
    private void Start()
    {
        TankModel tankModel = new TankModel();
        TankController tankController = new TankController(tankModel, _tankView);
    }
}
