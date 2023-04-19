using UnityEngine;
using UnityEngine.UI;
using Tank.EventService;
public class TankController
{
    private TypeDamagable Type;
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    private Button FireButton;
    private int countBullet;
    private bool isFiring = false;
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

   public async void Fire()
    {
        if(!isFiring)
            {
                isFiring = true;
                BulletSpawner.Instance.SpawnBullet(tankView.bulletSpawner.transform , tankModel.Type);
                countBullet++;
                EventManagement.Instance.PlayerShoot();
                await System.Threading.Tasks.Task.Delay(1000);
                isFiring = false;
        }
       /* if(isFiring)
            {
            }*/
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
    public void GetDamage(float damage, TypeDamagable type)
    {
        if(tankModel.Type == type)
            return;
        tankModel.Health -= damage/5;
        if(tankModel.Health <= 0)
        {
            tankView.DestroyObj();
            EventManagement.Instance.PlayerDeath();
        }
    }
}
