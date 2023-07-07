using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    private Vector3 movementDirection;
   

    private float tankSpeed;
    private Rigidbody rb;

   

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);

       

        tankSpeed = tankModel.Speed;
        rb = tankView.GetRigidbody();


        tankView.SetTankController(this);
        tankModel.SetTankController(this);
    }


    public void TankMove()
    {
        // Get the UIService instance
        UIService uiService = UIService.Instance;
        if (uiService == null)
        {
            Debug.LogError("UIService instance is missing or not properly initialized.");
            return;
        }

        movementDirection.x = uiService.GetJoystickHorizontal();

        movementDirection.z = uiService.GetJoystickVertical();
        

       tankView.GetRigidbody().velocity = movementDirection * tankModel.Speed * Time.fixedDeltaTime;
        if (movementDirection != Vector3.zero)
        {
            tankView.transform.forward = movementDirection;
        }
    }


    public TankModel GetModel()
    {
        return tankModel;
    }
}
