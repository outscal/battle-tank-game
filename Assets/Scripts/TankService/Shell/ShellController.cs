using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    public class ShellController
    {
        public ShellModel GetShellModel { get; }
        public ShellView GetShellView { get; }

        public ShellController(ShellModel _shellModel, ShellView shellViewPrefab, Transform spawnPoint)
        {
            GetShellModel = _shellModel;
            GetShellView = Object.Instantiate(shellViewPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        public float CalculateDamage(Vector3 tankPosition, Vector3 impactPosition)
        {
            float explosionDistance = Vector3.Distance(tankPosition, impactPosition);

            float relativeDistance = (GetShellModel.ExplosionRadius - explosionDistance) / GetShellModel.ExplosionRadius;

            float damage = relativeDistance * GetShellModel.MaxDamage;
            damage = Mathf.Max(damage, 0f);
            return damage;
        }
    }
}
