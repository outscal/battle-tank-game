using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is Attached to a Player Tank GameObject and is responsible for UI related work.
/// </summary>

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private Joystick joystick;
    public Rigidbody rigidbody;
    [SerializeField] private TankType tankType;
    public float movement;
    public float rotation;

    //// Sets a reference to the corresponding TankController Script.
    // TankController <- TankView.
    public void SetTankControllerReference(TankController _tankController)
    {
        tankController = _tankController;
    }

    private void Start()
    {
        joystick = tankController.GetJoystickReference();

        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.SetParent(transform);
        camera.transform.position = new Vector3(0f, 3f, -5f);
    }

    private void FixedUpdate()
    {
        Movement();
        if (movement != 0)
            tankController.Move(rigidbody, movement,tankController.tankModel.MovementSpeed);

        if (rotation != 0)
            tankController.Rotate(rigidbody, rotation, tankController.tankModel.RotationSpeed);
    }

    public Rigidbody GetRigidbody()
    {
        return rigidbody;
    }
        
    private void Movement()
    {
        movement = joystick.Vertical;
        rotation = joystick.Horizontal;
    }
}
