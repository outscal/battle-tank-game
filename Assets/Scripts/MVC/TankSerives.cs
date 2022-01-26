using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSerives : TankSingletonGeneric<TankSerives>
{
    [SerializeField] private TankView tankView;

    TankModel tankModel = new TankModel(2, 100);

    private void Start()
    {
        TankController tankController = new TankController(tankModel, tankView);
    }
}
