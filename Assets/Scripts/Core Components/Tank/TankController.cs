using UnityEngine;

public class TankController
{
    public TankModel TankModel { get; protected set; }
    public TankView TankView { get; protected set; }

    public TankController(TankScriptableObject tankScriptableObject)
    {
        // Override this constuctor is approriate derived class
    }

    protected void HandleMovement(float horizontal, float vertical, float timeVariance)
    {
        Vector3 position = TankView.Position;
        position.x += horizontal * TankModel.Speed * timeVariance;
        position.z += vertical * TankModel.Speed * timeVariance;

        Vector3 rotation = new Vector3(horizontal, position.y, vertical);

        TankView.Rotation = Quaternion.LookRotation(rotation);
        TankView.Position = position;
        TankView.ApplyTranform = true;
    }

    protected void Shoot()
    {
        AmmoScriptableObject ammoScriptableObject = TankModel.AmmoScriptableObject;

        switch (ammoScriptableObject.AmmoType)
        {
            case AmmoType.Bullet:
                new BulletController((BulletScriptableObject)ammoScriptableObject, this, TankView.BulletSpawnPosition);
                break;
        }
    }

    public void TakeDamage(float damage)
    {
        TankModel.CurrentHealth -= damage;

        if (TankModel.CurrentHealth <= 0)
        {
            TankModel.IsAlive = false;
        }
    }
}