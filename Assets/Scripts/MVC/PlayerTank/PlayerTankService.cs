using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    public PlayerTankView TankView;
    public TankScriptableObjectList PlayerTankList;
    public BulletScriptableObjectList BulletList;
    public Joystick RightJoystick;
    public Joystick LeftJoystick;
    public Camera Camera;

    private PlayerTankController tankController;

    private void Start()
    {
        tankController = CreatePlayerTank();
        tankController.SetJoystickReference(RightJoystick, LeftJoystick);
        tankController.SetCameraReference(Camera);
    }

    private void FixedUpdate()
    {
        tankController.FixedUpdateTankController();
    }

    private PlayerTankController CreatePlayerTank()
    {
        PlayerTankModel model = new PlayerTankModel(100, 10, 10, 80, 40);
        PlayerTankController tank = new PlayerTankController(model, TankView);

        // Passing reference of controller to TankView.
        tank.TankView.SetTankControllerReference(tank); 

        return tank;
    }
}
