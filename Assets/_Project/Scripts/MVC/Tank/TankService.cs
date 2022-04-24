using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.MVC;

public class TankService : MonoBehaviour
{
    public TankView tankView;

    public TankScriptableObjectList tankScriptableObjectList;
    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        for (int i = 0; i < tankScriptableObjectList.tanks.Length; i++)
            CreateNewTank(i);
    }

    private TankController CreateNewTank(int index)
    {
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[index];
        Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
