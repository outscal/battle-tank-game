using UnityEngine;

public class TankController
{    
    private Joystick joystick;

    // Speed variables.
    private float MovementSpeed;

    public TankModel tankModel { get; }
    public TankView tankView { get; }

    // model <- controller -> view
    public TankController(TankModel _tankModel, TankView _tankView, Joystick _joystick)
    {
        tankModel = _tankModel;
        joystick = _joystick;

        MovementSpeed = tankModel.MovementSpeed;
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

    public void Move(Rigidbody tankRigidBody, float movement, float rotation, Transform transform)
    {
        tankRigidBody.velocity = new Vector3(rotation * MovementSpeed, tankRigidBody.velocity.y, movement * MovementSpeed);

    }

    public void Rotate(Rigidbody tankRigidBody, Transform transform)
    {
        transform.rotation = Quaternion.LookRotation(tankRigidBody.velocity);
    }
}
