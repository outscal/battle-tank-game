using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;
    private TankView _tankview;

    private Rigidbody rb; 

    //contructor for setting up the references
    public TankController(TankModel _tankModel, TankView _tankview) 
    {   
        //filling the reference of tankmodel 
        tankModel = _tankModel;

        //get the reference from instantiated tankView gameobject which is just spawned        
        tankView = GameObject.Instantiate<TankView>(_tankview);;
        
        //getting rigidbody refernce
        rb = tankView.GetRigidBody();

        //passing the reference to the function of this tankcontroller where this script is attached 
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }//end contructor

    //method for tank Movement
    public void TankMovement(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    //method for tank turn
    public void TankRotation(float rotation, float rotationSpeed)
    {   
        //capturing at how much delta the tank is rotating
        Vector3 tankTurn = new Vector3(0f, rotation * rotationSpeed, 0f);
        //quaternion = measurement of rotation, euler = measurement of angles
        Quaternion deltaRotation = Quaternion.Euler(tankTurn * Time.deltaTime);
        //rotating the tank using the rigibody rotation 
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    //As per MVC view cant directly access the data from model so this is refernce created in controller to access model
    public TankModel GetTankModel()
    {
        return tankModel;
    }

}//end class
