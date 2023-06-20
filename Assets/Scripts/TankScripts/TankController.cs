using UnityEngine;
public class TankController
{
    public TankController(TankView _tankView)
    {
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel = new TankModel(10, 100);

        tankView.SetTankController(this);
        tankModel.SetTankController(this);
    }
    public TankModel tankModel { get; }
    public TankView tankView { get; }
}
