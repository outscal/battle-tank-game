namespace BattleTank.Enum
{
    public enum TankType
    {
        None,
        Blue,
        Green,
        Red
    }

    public enum BulletType
    {
        None,
        Slow,
        Normal,
        Fast
    }

    public enum ExplosionType
    {
        TankExplosion,
        BulletExplosion
    }

    public enum TankID
    {
        Player,
        Enemy
    }

    public enum ObjectPoolType
    {
        BulletPool,
        EnemyTankPool,
        BulletParticlePool,
        TankParticlePool
    }
}