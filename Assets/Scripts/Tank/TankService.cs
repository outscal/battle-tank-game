using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;
    
    public void Start()
    {
       StartGame();
    }
    public void StartGame()
    {
        for(int i = 0; i < 10; i++)
        {
            CreateNewTank();
        }
    }
    private TankController CreateNewTank()
    {
        TankModel model = new TankModel(5, 100f);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
