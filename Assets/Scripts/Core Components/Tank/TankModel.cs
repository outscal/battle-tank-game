public class TankModel
{
    public string TankName { get; private set; }
    public TankCategory TankCategory { get; private set; }
    public TankType TankType { get; private set; }

    public float Speed { get; private set; }
    public float Health { get; private set; }
    public float FireRate { get; private set; }
    public float Damage { get; private set; }

    public AmmoScriptableObject AmmoScriptableObject { get; private set; }

    public float CurrentHealth { get; set; }
    public float TimeLeftForNextShot { get; set; }
    public bool IsAlive { get; set; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankName = tankScriptableObject.TankName;
        TankCategory = tankScriptableObject.TankCategory;
        TankType = tankScriptableObject.TankType;

        Speed = tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        FireRate = tankScriptableObject.FireRate;
        Damage = tankScriptableObject.Damage;

        AmmoScriptableObject = tankScriptableObject.AmmoScriptableObject;

        CurrentHealth = tankScriptableObject.Health;
        TimeLeftForNextShot = tankScriptableObject.FireRate;
        IsAlive = CurrentHealth > 0;
    }
}