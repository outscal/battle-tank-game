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
   // PlayerMovement playerMovement;
    private Rigidbody tankRigidbody;

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        //TankView = GameObject.Instantiate<TankView>(tankPrefab); 
        TankView = Object.Instantiate(tankPrefab);
        tankRigidbody = TankView.GetComponent<Rigidbody>();
        TankView.setTankControllerReference(this);
        // Debug.Log("Tank View created");
      //  playerMovement.SetPlayerMovementReference(joystick);
    }

    public void setJoystickreference(FixedJoystick joystick)
    {
        this.joystick = joystick;
    }

    public void ApplyDamage(int damage)
    {
        //Update model to reflect the damage
        if(TankModel.Health - damage <= 0)
        {
            //Death Sequence

        }
        else
        {
            //Change the health value
            TankModel.Health -= damage;
            Debug.Log("Player took damage :" + TankModel.Health);
        }
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

    private void AddForwardMovementInput()
    {
        Vector3 forwardInput = tankRigidbody.transform.position + joystick.Vertical * tankRigidbody.transform.forward * TankModel.Speed * Time.deltaTime;
        tankRigidbody.MovePosition(forwardInput);
    }

    public void FixedupdateTankController()
    {
        AddForwardMovementInput();
        Debug.Log("MOvement happeing");
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; } 
    
}
