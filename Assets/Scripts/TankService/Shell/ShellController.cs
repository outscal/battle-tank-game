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

        public void CheckHitColliders(Collider[] hitColliders, int numOfColliders, Vector3 bulletPosition)
        {
            for (int i = 0; i < numOfColliders; i++)
            {
                Rigidbody targetRb = hitColliders[i].gameObject.GetComponent<Rigidbody>();

                // go to next collider
                if (!targetRb) continue;

                targetRb.AddExplosionForce(CreateShellService.Instance.GetBulletModel.ExplosionForce, bulletPosition, CreateShellService.Instance.GetBulletModel.ExplosionRadius);

                // need to create a tankHealth script or use it in GetTankModel
                // take health value from current tank-gameObj - targetRb
                TankView targetTankView = targetRb.GetComponent<TankView>();
                TankController targetTank = targetTankView.GetTankController();
                if (targetTank == null) continue;

                float damage = CalculateDamage(targetTankView.transform.position, bulletPosition);
                //Debug.Log($"Damage: {damage}");
                targetTank.TakeDamage(damage);
            }
        }

        private float CalculateDamage(Vector3 tankPosition, Vector3 impactPosition)
        {
            // Slightly less accurate Distance
            float explosionDistance = (tankPosition - impactPosition).sqrMagnitude;
            //Debug.Log($"Dist1: {explosionDistance}");
            //float explosionDistance2 = Vector3.Distance(tankPosition, impactPosition);
            //Debug.Log($"Dist2: {explosionDistance2}");

            float relativeDistance = (GetShellModel.ExplosionRadius - explosionDistance) / GetShellModel.ExplosionRadius;

            float damage = relativeDistance * GetShellModel.MaxDamage;
            damage = Mathf.Max(damage, 0f);
            return damage;
        }
    }
}
