using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    public BulletSpawner bulletSpawner;
    private float movement;
    private float rotation;
    public List<Material> colors;
    [SerializeField] private MeshRenderer Chasis;
    [SerializeField] private MeshRenderer Turret;
    [SerializeField] private Rigidbody rb;
    private Joystick joystick;
    public void SetJoyStick(Joystick joyStick)
    {
        joystick = joyStick;
    }
    private void Start() {
        Chasis.material = tankController.GetTankModel().color;
        Turret.material = tankController.GetTankModel().color;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().moveSpeed);
        }
        if(rotation != 0)
        {
            tankController.Turn(rotation, tankController.GetTankModel().TurnSpeed);
        }
    }
    
    private void Movement()
    {
        movement = joystick.Vertical;
        rotation = joystick.Horizontal;
    }
    public void Fire()
    {
        bulletSpawner.SpawnBullet(this.transform);
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void SetTankController(TankController tankcontroller)
    {
        tankController = tankcontroller;
    }
}