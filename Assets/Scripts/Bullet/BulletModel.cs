using UnityEngine;

namespace Bullet
{
    [System.Serializable]
    public class BulletModel
    {
        [SerializeField] private float lifeTime = 5000 ;
        [SerializeField] private float speed = 8;
        
        private float _damage;
        
        public BulletModel(){}

        public BulletModel(BulletModel other)
        {
            lifeTime = other.LifeTime;
            speed = other.Speed;
        }
        public float LifeTime => lifeTime;
        public void DecreaseLifeTime(float time) => lifeTime -= time;
        public float Damage => _damage;
        public void SetDamage(float damage) => _damage = damage;
        public float Speed => speed;
    }
}