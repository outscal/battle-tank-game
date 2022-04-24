public class TankModel
{
    public TankType TankType { get; }
    public float tankSpeed { get; } // public get; private set
    public float tankTurnSpeed { get; }
    public int tankHealth { get; }
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.tankType;
        tankSpeed = (float)tankScriptableObject.speed;
        tankTurnSpeed = (float)tankScriptableObject.tankTurnSpeed;
        tankHealth = (int)tankScriptableObject.Health;
    }
}