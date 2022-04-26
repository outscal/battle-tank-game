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
        float tankTurn;
        if(tankModel.movementInput != 0)
        {
            tankTurn = tankModel.movementInput * tankModel.turnInput * tankModel.rotationSpeed * Time.deltaTime;
        }
        else
        {
            tankTurn = tankModel.turnInput * tankModel.rotationSpeed * Time.deltaTime;
        }
        Quaternion turnRotation = Quaternion.Euler(0f, tankTurn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

}//end class
