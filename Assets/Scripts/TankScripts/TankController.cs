using UnityEngine;
public class TankController
{
    public TankController(TankView _tankView, FixedJoystick _joystick, float _speed, float _health)
    {
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel = new TankModel(_speed, _health);

        tankView.SetTankController(this);
        tankModel.SetTankController(this);

        tankView.SetJoystick(_joystick);
        rb = tankView.GetRigidbody();
    }
    public TankModel tankModel { get; }
    public TankView tankView { get; }
    private Rigidbody rb;
    Vector3 direction;
    public void MoveTank(float _horizontalMove, float _verticalMove)
    {
        direction = Vector3.forward * _verticalMove + Vector3.right * _horizontalMove;
        direction = Quaternion.Euler(0, 60, 0) * direction;

        rb.velocity = direction * tankModel.speed;
        tankView.transform.LookAt(direction.normalized + tankView.transform.position);
    }
}
