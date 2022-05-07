using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView =  GameObject.Instantiate<TankView>(_tankView);
         rb = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);

       
       
    }
    
     public void Move(float movementInput , float movementSpeed)
     {
          rb.velocity = tankView.transform.forward * movementInput * movementSpeed;
     }
        
    public void Rotate(float rotationInput , float rotateSpeed)
    {
         Vector3 vector = new Vector3(0f,rotationInput*rotateSpeed,0f);
         Quaternion deltaRotation = Quaternion.Euler(vector*Time.deltaTime);
         rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }

}
