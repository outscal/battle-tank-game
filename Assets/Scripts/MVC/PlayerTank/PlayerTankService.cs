using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    public PlayerTankView TankView;
    public TankScriptableObjectList PlayerTankList;
    public Joystick RightJoystick;
    public Joystick LeftJoystick;
    public Camera Camera;

    private PlayerTankController tankController;
    private TankType playerTankType;

    private void Start()
    {
        playerTankType = TankType.Green;
        
        tankController = CreatePlayerTank(playerTankType);

        SetPlayerTankControlReferences();
    }

    private void FixedUpdate()
    {
        if(tankController != null)
        {
            tankController.FixedUpdateTankController();
        }
    }

    private PlayerTankController CreatePlayerTank(TankType tanktype)
    {
        foreach (TankScriptableObject tank in PlayerTankList.tanks)
        {
            if (tank.TankType == playerTankType)
            {
                PlayerTankModel tankModel = new PlayerTankModel(PlayerTankList.tanks[(int)tanktype].Health,
                                                                PlayerTankList.tanks[(int)tanktype].MovementSpeed,
                                                                PlayerTankList.tanks[(int)tanktype].RotationRate,
                                                                PlayerTankList.tanks[(int)tanktype].TurretRotationRate);

                PlayerTankController tankController = new PlayerTankController(tankModel, TankView);
                return tankController;
            }
        }
        return null;   
    }

    private void SetPlayerTankControlReferences()
    {
        if(tankController != null)
        {
            tankController.SetJoystickReference(RightJoystick, LeftJoystick);
            tankController.SetCameraReference(Camera);
        }
    }
}
