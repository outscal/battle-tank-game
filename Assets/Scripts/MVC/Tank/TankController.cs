
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

    public void MoveTank(float speed)
    {
        Vector3 movement = new Vector3(tankView.GetJoystick().Horizontal, 0f, tankView.GetJoystick().Vertical);
        rb.velocity = movement * speed;
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }


}
