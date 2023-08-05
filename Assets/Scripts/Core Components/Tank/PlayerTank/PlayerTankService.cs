using UnityEngine;
using UnityEngine.UI;

public class PlayerTankService : TankService<PlayerTankService>
{

    [SerializeField]
    PlayerTankScriptableObject PlayerTankScriptableObject;

    [SerializeField]
    Joystick Joystick;

    [SerializeField]
    Button ShootButton;

    protected override void Initialize()
    {
        if (PlayerTankScriptableObject != null)
        {
            new PlayerTankController(PlayerTankScriptableObject, Joystick, ShootButton);
        }
    }
}