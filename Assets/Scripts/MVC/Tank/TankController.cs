
using UnityEngine;

public class TankController 
{
    private Rigidbody rb;
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel _tankModel,TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = Object.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidbody();

        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }

    
    public TankModel GetTankModel()
    {
        return tankModel;
    }


}
