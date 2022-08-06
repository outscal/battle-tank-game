using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is Attached to a Player Tank GameObject and is responsible for UI related work.
/// </summary>

public class TankView : MonoBehaviour
{
    private TankController tankController;
    public Rigidbody rigidbody;

    //// Sets a reference to the corresponding TankController Script.
    // TankController <- TankView.
    public void SetTankControllerReference(TankController _tankController)
    {
        tankController = _tankController;
    }

    private void FixedUpdate()
    {
        tankController.HandleJoyStickInput();
    }

    public Rigidbody GetRigidbody()
    {
        return rigidbody;
    }
        
}
