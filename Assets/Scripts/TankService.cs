using System.Collections;
using System.Collections.Generic;
using Tanks.Tank;
using UnityEngine;
using System;

public class TankService : MonoBehaviour
{

    public TankView tankView;
    public GameObject wrongTankView;

    //public TankScriptableObject[] tankConfiguration;

    public TankScriptableObjectList tankList;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        for (int i = 0; i < 2; i++)
        {
            CreateNewTank(i);
        }
        
    }

    private TankControllerScript CreateNewTank(int index)
    {

        //TankScriptableObject tankScriptableObject = tankConfiguration[2];
        TankScriptableObject tankScriptableObject = tankList.tanks[2];

        TankModel model = new TankModel(tankScriptableObject);
        //TankModel model = new TankModel(TankType.None, 5, 100f);
        TankControllerScript tank = new TankControllerScript(model, tankView);
        return tank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
