using UnityEngine;

public class TankController
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public TankController(TankModel _tankModel, TankView _tankViewPrefab)
    {
        TankModel = _tankModel;
        TankView = GameObject.Instantiate<TankView>(_tankViewPrefab);
    }
}