using UnityEngine;
public class TankController
{
    public TankController(TankView _tankView, float _speed, float _health, TankType _tankType, FixedJoystick _joystick = null, CameraController cameraController = null, float x = 0, float z = 0)
    {
        if (_tankType == TankType.Player)
        {
            tankView = GameObject.Instantiate<TankView>(_tankView);
            cameraController.SetTankTransform(tankView.transform);
        }
        else
        {
            tankView = GameObject.Instantiate<TankView>(_tankView, new Vector3(Random.Range(-x, x), 0, Random.Range(-z, z)), Quaternion.identity);
        }
        tankModel = new TankModel(_speed, _health);

        tankView.SetTankController(this);
        tankView.SetTankType(_tankType);
        tankModel.SetTankController(this);

        if (_joystick != null)
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
