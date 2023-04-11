using BattleTank.Enum;

namespace BattleTank.Interface
{
    public interface IDamageable
    {
        void Damage(TankID tankID, float damage);
        TankID GetTankID();
    }
}