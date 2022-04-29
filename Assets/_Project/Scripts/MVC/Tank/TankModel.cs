public class TankModel
{
    public TankType TankType { get; }
    internal float currentHealth;
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

    public float getHealth()
    {
        return currentHealth;
    }
}