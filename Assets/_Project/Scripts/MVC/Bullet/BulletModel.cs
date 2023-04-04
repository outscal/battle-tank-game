using BattleTank.BulletSO;

namespace BattleTank.Bullet
{
    public class BulletModel
    {
        public float Damage { get; private set; }
        public float Speed { get; private set; }

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            Damage = bulletScriptableObject.Damage;
            Speed = bulletScriptableObject.Speed;
        }
    }
}