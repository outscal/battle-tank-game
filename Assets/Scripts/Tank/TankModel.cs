using UnityEngine;

namespace Tank
{
    [System.Serializable]
    public abstract class TankModel
    {
        #region Serialized Data Members

        [SerializeField] private float speed =5;
        [SerializeField] private float health =100;
        [SerializeField] private float damage =20;
        [SerializeField] private Scriptable_Object.Bullet.Bullet bullet;

        #endregion

        #region Protected Data Members

        protected TankType _type;

        #endregion

        #region Setters

        public virtual void DecreaseHealth(float amount)
        {
            Debug.Log("Decrease: "+amount+" New health: " + health);
            health -= amount;
        }

        #endregion

        #region Getters

        public TankType TankType => _type;

        public float Speed => speed;

        public float Health => health;

        public float Damage => damage;

        public Scriptable_Object.Bullet.Bullet Bullet => bullet;

        #endregion

        #region Constructors

        protected TankModel(){}

        protected TankModel(TankModel other)
        {
            speed = other.Speed;
            health = other.Health;
            damage = other.Damage;
            bullet = other.Bullet;
            _type = other.TankType;
        }

        #endregion
    }
}
