using Tank;
using UnityEngine;

namespace Bullet
{
    [System.Serializable]
    public class BulletModel
    {
        #region Serialized Data members

        [SerializeField] private float lifeTime = 5000;
        [SerializeField] private float speed = 8;
        [SerializeField] private TrajectoryType trajectory = TrajectoryType.None;

        #endregion

        #region Private Data members

        private float _damage;
        private TankType _tankType;

        #endregion

        #region Public Data members
        
        public TankType TankType => _tankType;
        public float LifeTime => lifeTime;
        public float Damage => _damage;
        public float Speed => speed;
        public TrajectoryType TrajectoryType => trajectory;
        
        #endregion

        #region Constructors

        public BulletModel(BulletModel other)
        {
            lifeTime = other.LifeTime;
            speed = other.Speed;
            trajectory = other.TrajectoryType;
        }

        #endregion

        #region Setters

        public void SetTankType(TankType type) => _tankType = type;
        public void SetDamage(float damage) => _damage = damage;

        #endregion

        #region Public Functions

        public void DecreaseLifeTime(float time) => lifeTime -= time;

        #endregion
    }
}