public class TankModel
{
    public TankType TankType { get; }

    public float tankSpeed { get; } // public get; private set
    public float tankTurnSpeed { get; }
    public float tankHealth { get; }
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.tankType;
        tankSpeed = tankScriptableObject.speed;
        tankTurnSpeed = tankScriptableObject.tankTurnSpeed;
        tankHealth = tankScriptableObject.Health;
    }
}