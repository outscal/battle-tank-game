
using UnityEngine;

public class PlayerTankController 
{
    public PlayerTankModel TankModel { get; }
    public PlayerTankView TankView { get; }

    public PlayerTankController(PlayerTankModel tankModel, PlayerTankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<PlayerTankView>(tankPrefab);
    }

}
