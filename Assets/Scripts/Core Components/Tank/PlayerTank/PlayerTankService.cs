using UnityEngine;
using UnityEngine.UI;

public class PlayerTankService : TankService<PlayerTankService>
{

    [SerializeField]
    PlayerTankScriptableObject playerTankScriptableObject;

    [SerializeField]
    Joystick joystick;

    [SerializeField]
    Button shootButton;

    protected override void Initialize()
    {
        if (playerTankScriptableObject == null)
            return;

        PlayerTankModel playerTankModel = new PlayerTankModel(playerTankScriptableObject);

        PlayerTankController playerTankController = new PlayerTankController(playerTankModel, playerTankScriptableObject, joystick, shootButton);
    }
}