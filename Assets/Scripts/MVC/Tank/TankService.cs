using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    //public GameObject tankView;

    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        for (int i = 0; i < 3; i++)
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
