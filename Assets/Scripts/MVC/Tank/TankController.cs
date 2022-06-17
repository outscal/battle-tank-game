using UnityEngine;


public class TankController
{
    public TankView _tankView;
    public TankModel _tankModel;
    public float _movementSpeed;
    public float _rotationSpeed;
    public Joystick _joystick;
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public TankController(TankModel tankModel, TankView tankView, Joystick joystick)
    {
        _joystick = joystick;
        _tankModel = tankModel;

        _movementSpeed = tankModel.MovementSpeed;
        _rotationSpeed = tankModel.RotationSpeed;

        _tankView = GameObject.Instantiate<TankView>(tankView);

        _tankModel.SetController(this);
        _tankView.SetController(this);
        SetTankColor(tankView, tankModel);

        Debug.Log("TankView created");
    }


    public void Move(Rigidbody rb, float movement, float rotation, Transform transform)
    {
        //adding velocity to rigidbody of the player tank game object
        //rb.velocity = transform.forward * movement * movementSpeed;
        //rb.velocity = new Vector3(movement * movementSpeed, rotation * rotationSpeed);

        rb.velocity = new Vector3(rotation * _movementSpeed, rb.velocity.y, movement * _movementSpeed);

    }

    public void Rotate(Transform transform, Rigidbody rb)
    {
        //rotating the rigidbody of the player tank game object
        // Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
        // Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        // rb.MoveRotation(rb.rotation * deltaRotation);

        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    public Joystick GetJoystick()
    {
        return _joystick;
    }

    public void SetTankColor(TankView tankview, TankModel tankModel)
    {
        //Get the Renderer component from the new cube
        var renderer = tankview.GetComponentInChildren<MeshRenderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        renderer.sharedMaterial.SetColor("_Color", tankModel.TankColor);
    }
}
