using Bullet;
using UnityEngine;

namespace Tank
{
    public abstract class TankController 
    {
        public TankModel TankModel { get; protected set; }
        public TankView TankView { get; }

        public TankController(TankView tankView)
        {
            TankView = GameObject.Instantiate(tankView);
            TankView.SetTankController(this);
        }

        public virtual void TakeDamage(float amount)
        {
            TankModel.DecreaseHealth(amount);
        }

        protected abstract void DestroyMe();

        public virtual void HitBy(Collision collision)
        {
            if (collision.gameObject.GetComponent<BulletView>())
            {
                Debug.Log("hit by bullet!");
                TakeDamage(collision.gameObject.GetComponent<BulletView>().BulletController.BulletModel.Damage);
            }
        }
    }
}
