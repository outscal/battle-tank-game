using UnityEngine;
public class TankController
{
    public TankController(TankScriptableObject tank, FixedJoystick _joystick = null, CameraController cameraController = null)
    {
        tankView = GameObject.Instantiate<TankView>(tank.tankView);
        cameraController.SetTankTransform(tankView.transform);
        tankModel = new TankModel(tank);

        tankView.SetTankController(this);
        tankModel.SetTankController(this);

        if (_joystick != null)
            tankView.SetJoystick(_joystick);
        rb = tankView.GetRigidbody();
        health = tankModel.health;
    }
    public TankModel tankModel { get; }
    public TankView tankView { get; }
    private Rigidbody rb;
    int health;
    Vector3 direction;
    public void MoveTank(float _horizontalMove, float _verticalMove)
    {
        direction = Vector3.forward * _verticalMove + Vector3.right * _horizontalMove;
        direction = Quaternion.Euler(0, 60, 0) * direction;

        rb.velocity = direction * tankModel.speed;
        tankView.transform.LookAt(direction.normalized + tankView.transform.position);
    }
    public void Shoot(Transform gunTransform)
    {
        TankService.Instance.ShootBullet(tankModel.bulletType, gunTransform);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            TankDeath();
    }
    void TankDeath()
    {
        TankService.Instance.DestoryTank(tankView);
    }
}
