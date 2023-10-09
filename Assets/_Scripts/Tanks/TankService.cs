using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    //public TankScriptableObject[] tankConfiguration;
    public TankScriptableObjectList tankList;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            CreateNewTank(i);
        }
    }

    private TankController CreateNewTank(int index)
    {
        //TankScriptableObject tankScriptableObject = tankConfiguration[2];
        TankScriptableObject tankScriptableObject = tankList.tanks[index];
        Debug.Log("Creating Tank with Type : " + tankScriptableObject.TankName);
        //TankModel model = new TankModel(TankType.Blue,5, 100f);
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
