using UnityEngine;

namespace Tank
{
    public class PlayerTankModel:TankModel
    {
        #region Serialized Data Members

        [SerializeField] private int lives;

        #endregion

        #region Private Data Members

        private float _currentHealth;

        #endregion

        #region Getters

        public float CurrentHealth => _currentHealth;
        public int Lives => lives;

        #endregion

        #region Constructors

        public PlayerTankModel() : base()
        {
            lives = 3;
            _type = TankType.Player;
            ResetCurrentHealth();
        }

        public PlayerTankModel(PlayerTankModel other):base(other)
        {
            lives = other.Lives;
            ResetCurrentHealth();
        }

        #endregion

        #region Public Functions

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

        #endregion
    }
}