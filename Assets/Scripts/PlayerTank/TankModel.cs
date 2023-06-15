namespace BattleTank.PlayerTank
{
    public class TankModel
    {
        public float MovementSpeed;
        public float RotationSpeed;
        public float Health;
        public TankType TankType;

        public TankController TankController { get; private set; }

        public void SetTankController(TankController tankController)
        {
            TankController = tankController;
        }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            TankType = tankScriptableObject.TankType;
            MovementSpeed = tankScriptableObject.MovementSpeed;
            RotationSpeed = tankScriptableObject.RotationSpeed;
            Health = tankScriptableObject.Health;
        }
    }
}