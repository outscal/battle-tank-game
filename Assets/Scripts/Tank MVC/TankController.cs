using UnityEngine;

public class TankController
{ 
    //private TankModel tankModel;
    //private TankView tankView;
   
    private Joystick joystick;
    private Rigidbody tankRigidBody;


    // Speed variables.
    private float Speed;
    private float RotationSpeed;
    private float SpeedMultipier = 0.001f;
    private float RotationSpeedMultiplier = 0.01f;

    public TankModel tankModel { get; private set;  }
    public TankView tankView { get; private set; }

    // model <- controller -> view
    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView); // spawning tank using TankView reference
        tankRigidBody = _tankView.GetRigidbody();
        Speed = tankModel.Speed;
        RotationSpeed = tankModel.RotationSpeed;

        // model -> controller <- view
        tankModel.SetTankControllerReference(this);
        tankView.SetTankControllerReference(this);        
    }

    // Sets the reference to joystick on the Canvas.
    public void SetJoystickReferences(Joystick _joyStick)
    {
        joystick = _joyStick;
    }

    // This Function Handles the Input from the Left Joystick.
    public void HandleJoyStickInput()
    {
        if (joystick.Vertical != 0)
        {
            //new Vector3(joystick.Horizontal * Speed, tankRigidBody.velocity.y, joystick.Vertical * Speed);
            Vector3 ZAxisMovement = tankRigidBody.transform.position + (tankRigidBody.transform.forward * joystick.Vertical * Speed * SpeedMultipier);
            tankRigidBody.MovePosition(ZAxisMovement);
        }

        if (joystick.Horizontal != 0)
        {
            Quaternion newRotation = tankRigidBody.transform.rotation * Quaternion.Euler(Vector3.up * joystick.Horizontal * RotationSpeed * RotationSpeedMultiplier);
            tankRigidBody.MoveRotation(newRotation);
        }
    }
}
