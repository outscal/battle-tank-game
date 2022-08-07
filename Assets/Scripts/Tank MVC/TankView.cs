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
    }

    private void FixedUpdate()
    {
        movement = joystick.Vertical;
        rotation = joystick.Horizontal;
        tankController.Move(rigidbody, movement, rotation, gameObject.transform);

        if(movement != 0 || rotation != 0)
        {
            tankController.Rotate(rigidbody, gameObject.transform);
        }
    }

    public Rigidbody GetRigidbody()
    {
        return rigidbody;
    }
        
}
