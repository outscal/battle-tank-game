using System;

namespace BattleTank
{
    public interface IDamageable
    {
        public void TakeDamage(BulletType bulletType, int Damage);
    }
}
