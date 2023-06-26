
using UnityEngine;

public class TankController 
{
    public TankModel tankModel { get; }
    public TankView tankView { get; }

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }


}
