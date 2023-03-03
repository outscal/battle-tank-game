namespace TankBattle.TankService
{
    public class TankModel
    {

        public TankModel(TankType.TankScriptableObject tankScriptableObject)
        {
            TankType = tankScriptableObject.tankType;
            Speed = tankScriptableObject.speed;
            RotateSpeed = tankScriptableObject.rotateSpeed;
            JumpForce = tankScriptableObject.jumpValue;
        }
        public TankModel(TankType.TankType tankType, float speed, float rotateSpeed, float jumpForce)
        {
            TankType = tankType;
            Speed = speed;
            RotateSpeed = rotateSpeed;
            JumpForce = jumpForce;
        }

        // read-only properties
        public TankType.TankType TankType { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public float JumpForce { get; }
    };
}