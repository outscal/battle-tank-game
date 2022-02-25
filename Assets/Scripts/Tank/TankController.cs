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
            TankView = GameObject.Instantiate<TankView>(tankView);
            TankView.SetTankController(this);
        }

        public abstract void Move();

        public abstract void HandleAttacks();

        public void TakeDamage(float amount)
        {
            TankModel.DecreaseHealth(amount);
            if(TankModel.Health<=0) DestroyMe();
        }

        private void DestroyMe()
        {
            GameObject.Destroy(TankView.gameObject);
            TankModel = null;
            TankService.Instance.Destroy(this);
        }
    }
}
