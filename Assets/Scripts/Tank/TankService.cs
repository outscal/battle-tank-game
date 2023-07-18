using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService> 
{
    [SerializeField] private TankView prefabTank;
    [SerializeField] private int TotalTanks;

    // Start is called before the first frame update
    void Start()
    {
        StartGAme();
    }

    void StartGAme()
    {
        for(int i=0; i< TotalTanks; i++)
        {
            CreateNewTank();
        }
    }
    private TankController CreateNewTank()
    {

        TankModel tankModel = new TankModel(10, 100f);
        TankController tankController = new TankController(tankModel, prefabTank);
        return tankController;
    }

}
