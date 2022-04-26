using System;
using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb; 

   public TankController(TankModel _tankModel, TankView _tankview) 
    {   
        tankModel = _tankModel;       
        tankView = GameObject.Instantiate<TankView>(_tankview);;        
        rb = tankView.GetRigidBody();

        tankView.SetTankController(this);
    }//end contructor

    //method for tankmovement forward and backward
   public void GetInput()
   {
       //getting the input left and right
       tankModel.movementInput = Input.GetAxis("Vertical");
       tankModel.turnInput = Input.GetAxis("Horizontal");
   }

    //method for tank Movement

    internal void Movement()
    {
        TankMovement(tankModel.movementInput, tankModel.movementSpeed);
        TankRotation(tankModel.turnInput, tankModel.rotationSpeed);
    }

    public void TankMovement(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    //method for tank turn
    public void TankRotation(float rotation, float rotationSpeed)
    {   
        Vector3 tankTurn = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(tankTurn * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

}//end class
