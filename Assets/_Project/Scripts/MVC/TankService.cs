using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        for(int i = 0; i < 10; i++)
        CreateNewTank();
    }

    private TankController CreateNewTank()
    {
        TankModel model = new TankModel(12, 100f);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
