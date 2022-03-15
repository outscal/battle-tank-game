
namespace BulletServices
{
    public class BulletModel
    {
        public int bulletDamage { get; }
        public float maxLifeTime { get; }
        public float explosionRadius { get; }
        public float explosionForce { get; }

        public BulletModel(int bulletDamage, float maxLifeTime, float explosionRadius, float explosionForce)
        {
            this.bulletDamage = bulletDamage;
            this.maxLifeTime = maxLifeTime;
            this.explosionRadius = explosionRadius;
            this.explosionForce = explosionForce;
        }
    }
}
