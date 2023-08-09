using UnityEngine;
using UnityEngine.UI;

public class PlayerTankService : TankService<PlayerTankService>
{

    [SerializeField]
    PlayerTankScriptableObject PlayerTankScriptableObject;

    // Following GameObjects will be destroyed from the scene
    [SerializeField]
    GameObject Ground, LevelArt;

    [SerializeField]
    Joystick Joystick;

    [SerializeField]
    Button ShootButton;

    protected override void Initialize()
    {
        if (PlayerTankScriptableObject != null)
        {
            PlayerTankController playerTankController = new PlayerTankController(PlayerTankScriptableObject, Joystick, ShootButton);

            playerTankController.GroundGameObject = Ground;
            playerTankController.LevelArtGameObject = LevelArt;
        }
    }
}