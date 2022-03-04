using Tank;
using UnityEngine;

namespace Bullet
{
    [System.Serializable]
    public class BulletModel
    {
        [SerializeField] private float lifeTime = 5000;
        [SerializeField] private float speed = 8;
        [SerializeField] private TrajectoryType trajectory = TrajectoryType.None;
        
        
        private float _damage;

        private TankType _tankType;

        public TankType TankType => _tankType;
        
        public BulletModel(){}

        public BulletModel(BulletModel other)
        {
            lifeTime = other.LifeTime;
            speed = other.Speed;
            trajectory = other.TrajectoryType;
        }
        public float LifeTime => lifeTime;
        public void DecreaseLifeTime(float time) => lifeTime -= time;
        public float Damage => _damage;
        public void SetDamage(float damage) => _damage = damage;

        public void SetTankType(TankType type) => _tankType = type;
        public float Speed => speed;

        public TrajectoryType TrajectoryType => trajectory;
    }
}