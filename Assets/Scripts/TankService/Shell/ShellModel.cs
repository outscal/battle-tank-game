using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    public class ShellModel
    {
        public ShellModel(ShellScriptableObject bulletShell)
        {
            LayerMask = bulletShell.layerMask;
            ExplosionForce = bulletShell.explosionForce;
            ExplosionRadius = bulletShell.explosionRadius;
            MaxDamage = bulletShell.maxDamage;
            MaxLifeTime = bulletShell.maxLifeInSeconds;
        }

        public LayerMask LayerMask { get; }
        public float ExplosionRadius { get; }
        public float ExplosionForce { get; }
        public float MaxDamage { get; }
        public float MaxLifeTime { get; }
    }
}
