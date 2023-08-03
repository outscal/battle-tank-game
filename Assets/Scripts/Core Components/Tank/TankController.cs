using UnityEngine;

public class TankController
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public TankController(TankModel tankModel, TankView tankViewPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankViewPrefab);
    }

    protected virtual void handleMovement(float horizontal, float vertical, float timeVariance)
    {
        Vector3 position = TankView.Position;
        position.x += horizontal * TankModel.Speed * timeVariance;
        position.z += vertical * TankModel.Speed * timeVariance;

        Vector3 rotation = new Vector3(horizontal, position.y, vertical);

        TankView.Rotation = Quaternion.LookRotation(rotation);
        TankView.Position = position;
        TankView.ApplyTranform = true;
    }

    protected virtual void shoot()
    {

    }
}