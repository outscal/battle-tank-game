using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;
    public TankScriptableObject[] tankConfigration;
    public void Start()
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
        TankScriptableObject tankScriptableObject = tankConfigration[index];
        Debug.Log("Creating Tank with Type " + tankScriptableObject.TankTypes);

        //TankScriptableObject tankScriptableObject = tankList.tanks[index];

        TankModel model = new TankModel(tankScriptableObject);
        //TankModel model = new TankModel(TankTypes.None,5, 100f);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
