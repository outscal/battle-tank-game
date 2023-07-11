using BattleTank.ScriptableObjects;

namespace BattleTank.Bullet
{
    public class BulletModel
    {
        public int damage { get; }
        public int range { get; }
        public TankType tankType { private set; get; }

        private BulletController bulletController;

        public BulletModel(BulletScriptableObject _bullet, TankType tankType)
        {
            damage = _bullet.damage;
            range = _bullet.range;
            this.tankType = tankType;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}
