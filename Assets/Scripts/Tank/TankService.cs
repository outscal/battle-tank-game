using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : SingletonGeneric<TankService>
{
    [SerializeField] private TankScriptableObjectList tankScriptableObjectList;

    private void Start()
    {
        CreateNewTank();
    }

    private TankController CreateNewTank()
    {
        int randomNumber = (int)Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScriptableObject tankObject = tankScriptableObjectList.tanks[randomNumber];
        Debug.Log("Created tank of type: " + tankObject.name);
        TankModel model = new(tankObject);
        TankController tank = new(model, tankObject.tankView);
        return tank;
    }
}
