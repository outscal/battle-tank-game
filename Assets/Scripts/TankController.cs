using UnityEngine;

public class TankController 
{

    private TankModel tankModel;
    private TankView tankView; 
    private Rigidbody rigidbody;
    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);


        rigidbody = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
        
    }

    public void Move(float movement, float movementSpeed)
    {
        
        rigidbody.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotate, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotationSpeed, 0f);
        Quaternion deltaRoation = Quaternion.Euler(vector * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRoation);
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
