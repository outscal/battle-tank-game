using UnityEngine;
using UnityEngine.UI;
public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    private Button FireButton;
    public TankController(TankModel tankmodel, TankView tankview, Joystick joyStick, Button fireButton)
    {
        FireButton = fireButton.GetComponent<Button>();
        FireButton.onClick.AddListener(Fire);
        this.tankModel = tankmodel;
        tankView = GameObject.Instantiate<TankView>(tankview);
        rb = tankView.GetRigidbody();
        this.tankView.SetJoyStick(joyStick);
        this.tankView.SetTankController(this);
        this.tankModel.SetTankController(this);
    }

   public void Fire()
    {
        BulletSpawner.Instance.SpawnBullet(tankView.bulletSpawner.transform);
    }

    public void Move(float movementDirection, float moveSpeed)
    {
        var moveForward = tankView.transform.forward * movementDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveForward);
    }
    public void Turn(float rotation, float TurnSpeed)
    {
        float turn = rotation * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }
    public void GetDamage(float damage)
    {
        tankModel.Health -= damage;
        if(tankModel.Health <= 0)
        {
            tankView.DestroyObj();
            DestroySequence.Instance.PlayerDeath();
        }
    }
}
