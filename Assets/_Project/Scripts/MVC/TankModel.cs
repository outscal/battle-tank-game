using BattleTank.Enum;
using BattleTank.TankSO;
using UnityEngine;

namespace BattleTank.Tank
{
    public class TankModel
    {
        public TankType TankType { get; private set; }
        public BulletType BulletType { get; private set; }
        public float Health { get; private set; }
        private float currentHealth;
        public float MovementSpeed { get; private set; }
        public float RotationSpeed { get; private set; }
        public float FireRate { get; private set; }
        public Material Material { get; private set; }
        public int TotalPercentage { get; private set; }
        public int HalfPercentage { get; private set; }
        public Color BackgroundColor { get; private set; }
        public Color ForegroundColor { get; private set; }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            TankType = tankScriptableObject.TankType;
            BulletType = tankScriptableObject.BulletType;
            Health = tankScriptableObject.Health;
            currentHealth = Health;
            MovementSpeed = tankScriptableObject.MovementSpeed;
            RotationSpeed = tankScriptableObject.RotationSpeed;
            FireRate = tankScriptableObject.FireRate;
            Material = tankScriptableObject.Material;
            TotalPercentage = tankScriptableObject.TotalPercentage;
            HalfPercentage = tankScriptableObject.HalfPercentage;
            BackgroundColor = tankScriptableObject.BackgroundColor;
            ForegroundColor = tankScriptableObject.ForegroundColor;
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