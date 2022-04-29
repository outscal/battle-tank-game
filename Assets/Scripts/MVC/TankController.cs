using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class implements all the logic which is required for a Tank Entity in the game to Operate as required.
/// </summary>
public class TankController
{
    private Joystick LeftJoyStick;
    private Joystick RightJoyStick;
    private float SpeedMultipier = 0.001f;
    private float RotationSpeedMultiplier = 0.01f;
    //private Camera camera;

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }

    // Sets the reference to left & right Joysticks on the Canvas.
    public void SetJoyStickReferences(Joystick leftJoyStick, Joystick rightJoyStick)
    {
        LeftJoyStick = leftJoyStick;
        RightJoyStick = rightJoyStick;
    }

    // Sets the reference to the Camera & makes it a child object of PLayer Tank.
    // public void SetCameraReference(Camera cameraRef)
    //{
    // camera = cameraRef;
    //camera.transform.SetParent(TankView.transform);
    //}

    // This Function Handles the Input from the Left Joystick.
    public void HandleLeftJoyStickInput(Rigidbody tankRigidBody)
    {
        if (LeftJoyStick.Vertical != 0)
        {
            Vector3 ZAxisMovement = tankRigidBody.transform.position + (tankRigidBody.transform.forward * LeftJoyStick.Vertical * TankModel.Speed * SpeedMultipier);
            tankRigidBody.MovePosition(ZAxisMovement);
        }

        if (LeftJoyStick.Horizontal != 0)
        {
            Quaternion newRotation = tankRigidBody.transform.rotation * Quaternion.Euler(Vector3.up * LeftJoyStick.Horizontal * TankModel.RotationSpeed * RotationSpeedMultiplier);
            tankRigidBody.MoveRotation(newRotation);
        }

    }

    // This Function Handles the Input recieved from the Right Joystick.
    public void HandleRightJoyStickInput(Transform turretTransform)
    {
        Vector3 desiredRotation = Vector3.up * RightJoyStick.Horizontal * TankModel.TurretRotationSpeed * RotationSpeedMultiplier;
        turretTransform.Rotate(desiredRotation, Space.Self);
    }

}