using UnityEngine;

namespace Tank
{
    public class PlayerTankModel:TankModel
    {
        [SerializeField] private int lives;

        private float _currentHealth;
        public float CurrentHealth => _currentHealth;
        public int Lives => lives;

        public PlayerTankModel() : base()
        {
            lives = 3;
            ResetCurrentHealth();
        }

        public PlayerTankModel(PlayerTankModel other):base(other)
        {
            lives = other.Lives;
            ResetCurrentHealth();
        }

        public override void DecreaseHealth(float amount)
        {
            _currentHealth -= amount;
        }

        public void DecreaseLives()
        {
            lives--;
        }
        public void ResetCurrentHealth()
        {
            _currentHealth = Health;
        }
    }
}