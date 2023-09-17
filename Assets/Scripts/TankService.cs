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

    public void StartGame()
    {
        CreateNewTank();
    }
    private TankController CreateNewTank()
    {
        TankModel model = new TankModel(5, 100f);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
