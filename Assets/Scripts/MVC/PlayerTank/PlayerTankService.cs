using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
{
    public PlayerTankView tankView;
    public TankScriptableObjectList playerTankList;
    public BulletScriptableObjectList bulletList;

    private void Start()
    {
        CreatePlayerTank();
    }

    private PlayerTankController CreatePlayerTank()
    {
        PlayerTankModel model = new PlayerTankModel(100, 10, 5);
        PlayerTankController tank = new PlayerTankController(model, tankView);
        return tank;
    }
}
