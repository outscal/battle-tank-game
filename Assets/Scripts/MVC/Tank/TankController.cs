using Assets.Scripts.MVC.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController
{

    private Button Btn;
    private BulletController bx;
    private FixedJoystick joystick;
    PlayerMovement playerMovement;

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        //TankView = GameObject.Instantiate<TankView>(tankPrefab);
        TankView = Object.Instantiate(tankPrefab);
        // Debug.Log("Tank View created");
        playerMovement.SetPlayerMovementReference(joystick);
    }

    public void shoot()
    {
        bx.SpawnBullet();
        Debug.Log("ButtonClicked");
        if (Input.GetMouseButtonDown(0))
        {
            
            
        }
    }
    void Update()
    {
        Debug.Log("Controller Update is called");
    }
    public TankModel TankModel { get; }
    public TankView TankView { get; } 
}
