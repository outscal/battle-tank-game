using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : Singleton<TankSpawner>
{
    public TankList tankObjectList;
    //public TankView tankView;
    public Joystick joystick;
     
    void Start()
    {
        for(int i = 0; i < 3; i++)
            TankSpawn(i);
    }
    private void TankSpawn(int i)
    {
        TankModel tankModel = new TankModel(tankObjectList.tanks[i]);
        //TankModel tankModel = new TankModel(20, 30);
        //TankController tankController = new TankController(tankModel, tankView, joystick);
        TankController tankController = new TankController(tankModel, tankObjectList.tanks[i].tankView, joystick);
    }
}
