using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService> 
{
    [SerializeField] private TankView playerTank;
    public Follower playerTankFollower;
    public TankController playerTankController;

    // Start is called before the first frame update
    private void Start() => StartGame();

    public TankView getPlayerTankView() => playerTank;
    void StartGame()
    {
         playerTankController = CreateNewTank();
    }
    private TankController CreateNewTank()
    {

        TankModel tankModel = new TankModel(10, 100f);
        TankController tankController = new TankController(tankModel, playerTank);
        return tankController;
    }

}
