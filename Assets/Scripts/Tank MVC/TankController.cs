using UnityEngine;

public class TankController
{    
    private Joystick joystick;

    public TankModel tankModel { get; }
    public TankView tankView { get; }

    // model <- controller -> view
    public TankController(TankModel _tankModel, TankView _tankView, Joystick _joystick)
    {
        tankModel = _tankModel;
        joystick = _joystick;

        tankView = GameObject.Instantiate<TankView>(_tankView); // spawning tank using TankView reference

        // model -> controller <- view
        tankModel.SetTankControllerReference(this);
        tankView.SetTankControllerReference(this);

        Debug.Log("tank Spawner");
    }

    // Sets the reference to joystick on the Canvas.
    public Joystick GetJoystickReference()
    {
        return joystick;
    }


    public void Move(Rigidbody tankRigidBody, float movement, float movementSpeed)
    {
        tankRigidBody.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(Rigidbody tankRigidBody, float rotate, float rotationSpeed)
    {
         //rotating the rigidbody of the player tank gameObject
        Vector3 vector = new Vector3(0f, rotate * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        tankRigidBody.MoveRotation(tankRigidBody.rotation * deltaRotation);
    }

    //Get the reference of tankModel.
    /*public TankModel GetTankModel()
    {
        return tankModel;
    }*/
}
