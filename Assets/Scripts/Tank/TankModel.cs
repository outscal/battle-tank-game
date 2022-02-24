using Bullet;
using UnityEngine;

namespace Tank
{
    [System.Serializable]
    public class TankModel
    {
        [SerializeField] private float speed =5;
        [SerializeField] private float health =100;
        [SerializeField] private float damage =20;
        [SerializeField] private BulletType bulletType = BulletType.None;
        public float Speed => speed;
        public float Health => health;
        public float Damage => damage;
        public BulletType BulletType => bulletType;
        public TankModel(){}

        public TankModel(TankModel other)
        {
            speed = other.Speed;
            health = other.Health;
            damage = other.Damage;
            bulletType = other.BulletType;
        }
    }
}
