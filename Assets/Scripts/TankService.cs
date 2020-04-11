using UnityEngine;
using Bullet;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankView tankView;

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            TankModel model = new TankModel(5, 100f, 180f, 1, 0.2f, 15f, KeyCode.F);
            TankController tank = new TankController(model, tankView);
        }


        public void Fire(Transform bulletTransform, float bulletDamange)
        {
            BulletService.Instance.SpawnBullet(bulletTransform, bulletDamange);
        }
    }
}
