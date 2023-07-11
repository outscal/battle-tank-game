using BattleTank.ScriptableObjects;

namespace BattleTank.PlayerTank
{
    public class TankModel
    {
        private TankController tankController;

        public int speed { get; }
        public int health { get; }

        public BulletType bulletType { get; }

        public TankModel(TankScriptableObject tank)
        {
            speed = tank.speed;
            health = tank.health;

            bulletType = tank.bulletType;
        }

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
    }
}
