using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService> {

    [SerializeField] private TankView tankView;
    private TankController tankController;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(10, 50);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
