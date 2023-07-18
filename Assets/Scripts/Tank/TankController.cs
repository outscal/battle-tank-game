
using UnityEngine;

public class TankController
{
    public TankController(TankModel tankModel, TankView prefabTankView)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(prefabTankView);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }


}
