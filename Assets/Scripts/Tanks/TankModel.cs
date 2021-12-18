using BulletSO;
using TankSO;

namespace TankServices
{
    public class TankModel
    {
        private TankController tankController;
        public TankType TankType { get; private set; }
        public BulletScriptableObject BulletType { get; private set; }
        public float FireRate { get; private set; }
        public float MovSpeed { get; private set; }
        public float RotSpeed { get; private set; }
        public float Health { get; set; }

        public TankModel(TankScriptableObjects tankScriptableObjects)
        {
            TankType = tankScriptableObjects.tankType;
            MovSpeed = tankScriptableObjects.movSpeed;
            RotSpeed = tankScriptableObjects.rotSpeed;
            Health = tankScriptableObjects.health;
            BulletType = tankScriptableObjects.bulletType;
            FireRate = tankScriptableObjects.fireRate;
        }

        public TankModel(float movementSpeed, float rotationSpeed, float health)
        {
            MovSpeed = movementSpeed;
            RotSpeed = rotationSpeed;
            Health = health;
        }

        public void SetTankController(TankController tankControl)
        {
            tankController = tankControl;
        }

        public void destroyModel()
        {
            BulletType = null;
            tankController = null;
        }
    }
}
