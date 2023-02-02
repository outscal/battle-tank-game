using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : Singleton<TankSpawner>
{
    public TankView tankView;
     
    void Start()
    {
        TankSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TankSpawn()
    {
        TankModel tankModel = new TankModel(20, 30);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
