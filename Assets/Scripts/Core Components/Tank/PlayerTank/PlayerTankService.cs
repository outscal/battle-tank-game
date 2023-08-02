using UnityEngine;

public class PlayerTankService : TankService<PlayerTankService>
{

    [SerializeField]
    PlayerTankScriptableObject playerTankScriptableObject;

    [SerializeField]
    Joystick joystick;

    protected override void Initialize()
    {
        PlayerTankModel playerTankModel = new PlayerTankModel(playerTankScriptableObject);

        PlayerTankController playerTankController = new PlayerTankController(playerTankModel, playerTankScriptableObject.PlayerTankViewPrefab, joystick);
    }
}