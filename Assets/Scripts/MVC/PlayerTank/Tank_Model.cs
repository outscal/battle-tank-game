public class Tank_Model 
{
    public Tank_Model(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        RotationSpeed = tankScriptableObject.RotationSpeed;

    }

    public TankType TankType { get; }
    public int Speed { get; }
    public int Health { get; set; }

    public float RotationSpeed { get; }

}
