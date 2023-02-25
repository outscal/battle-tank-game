using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSpawner : Singleton<TankSpawner>
{
    public TankList tankObjectList;
    //public TankView tankView;
    public Joystick joystick;
    public Button fireButton;
    void Start()
    {
            TankSpawn(1);
    }
    private void TankSpawn(int i)
    {
        TankModel tankModel = new TankModel(tankObjectList.tanks[i]);
        TankController tankController = new TankController(tankModel, tankObjectList.tanks[i].tankView, joystick, fireButton);
    }
}
