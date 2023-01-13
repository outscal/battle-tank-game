using UnityEngine;

public class TankController 
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("Tank View Created", TankView);
    }

}