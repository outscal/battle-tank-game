using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankView : MonoBehaviour
{
    public PlayerTankController TankController { get;private set; }

    private Rigidbody rb;

    public GameObject BulletShooter;

    public PlayerTankModel tankModel;


    public void SetTankController(PlayerTankController tankController)
    {
        TankController = tankController;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        TankController.SetRigidBody(rb);
        tankModel = TankController.TankModel;
        DestoryEverything.Instance.PlayerTank = this;
    }
    void Update()
    {
        Movement();
        if(Input.GetMouseButtonDown(0))
        {
            TankController.FireBullet(BulletShooter.transform.position);
        }
    }

    private void Movement()
    {
        float move = Input.GetAxis("Vertical1");
        if (move != 0)
            TankController.MoveTank(move);
        float rotation = Input.GetAxisRaw("Horizontal1");
        if (rotation != 0)
            TankController.RotateTank(rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyTankView>())
        {
            TankController.PlayerDead();
        }
        else if (collision.gameObject.GetComponent<BulletView>())
        {
            TankController.TakeDamage(collision.gameObject.GetComponent<BulletView>());
        }
    }

    
}
