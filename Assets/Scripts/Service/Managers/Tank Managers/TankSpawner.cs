using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSpawner : Singleton<TankSpawner>
{
    [SerializeField] private TankList tankObjectList;
    //public TankView tankView;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button fireButton;
    public void TankSpawn(int i)
    { 
        TankModel tankModel = new TankModel(tankObjectList.tanks[i]);
        TankController tankController = new TankController(tankModel, tankObjectList.tanks[i].tankView, joystick, fireButton);
    }
}
