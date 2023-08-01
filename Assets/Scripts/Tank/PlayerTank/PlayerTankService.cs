using UnityEngine;

public class PlayerTankService : TankService<PlayerTankService>
{

    [SerializeField]
    protected PlayerTankView PlayerTankViewPrefab;

    [SerializeField]
    Joystick joystick;

    protected override void Initialize()
    {
        TankModel = new PlayerTankModel(tankSpeed, tankHealth);
        TankController = new PlayerTankController((PlayerTankModel)TankModel, PlayerTankViewPrefab, joystick);
    }
}