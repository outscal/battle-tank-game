using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    public TankView tankView;
    private TankModel currentTankModel;
    private TankController tankController;
    // public TankScriptableObject[] tankConfiguration;
    public TankScriptableObjectList tankList;

    private void Start()
    {
        CreateNewTank();
    }

    private TankController CreateNewTank()
    {
        // TankScriptableObject tankScriptableObject = tankConfiguration[1];
        TankScriptableObject tankScriptableObject = tankList.tanks[2];
        TankModel model = new TankModel(tankScriptableObject);
        // TankModel model = new TankModel(TankType.None,5, 100);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}