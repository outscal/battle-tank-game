using UnityEngine;
using UnityEngine.UI;
using System;
using Tank.EventService;
public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    private Button FireButton;
    int countBullet;
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
        Debug.Log("Player Fired");
        countBullet++;
        EventManagement.Instance.PlayerShoot();
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
            EventManagement.Instance.PlayerDeath(); // null refference here
            //DestroySequence.Instance.PlayerDeath();
        }
    }
}
