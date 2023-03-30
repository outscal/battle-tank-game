using UnityEngine;

namespace BattleTank
{
    public class TankModel
    {
        public TankType TankType { get; private set; }
        public BulletType BulletType { get; private set; }
        public float health { get; private set; }
        private float currentHealth;
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float fireRate { get; private set; }
        public Material material { get; private set; }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            TankType = tankScriptableObject.TankType;
            BulletType = tankScriptableObject.BulletType;
            health = tankScriptableObject.health;
            currentHealth = health;
            movementSpeed = tankScriptableObject.movementSpeed;
            rotationSpeed = tankScriptableObject.rotationSpeed;
            fireRate = tankScriptableObject.fireRate;
            material = tankScriptableObject.material;
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public void SetCurrentHealth(float _currHealth)
        {
            currentHealth = _currHealth;
        }
    }
}