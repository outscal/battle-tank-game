using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = _tankView;
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        GameObject.Instantiate(tankView.gameObject);
    }
}
