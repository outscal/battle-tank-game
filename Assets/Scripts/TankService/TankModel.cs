namespace TankBattle.Tank.Model
{
    public class TankModel
    {
        public TankModel(TankTypes.TankScriptableObject tankScriptableObject)
        {
            TankTypes = tankScriptableObject.tankType;
            Speed = tankScriptableObject.speed;
            RotateSpeed = tankScriptableObject.rotateSpeed;
            JumpForce = tankScriptableObject.jumpValue;
        }

        // read-only properties
        public TankType TankTypes { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public float JumpForce { get; }
    };
}