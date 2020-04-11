
using UnityEngine;

namespace Tank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            TankView.Initialize(this);
        }

        public TankModel TankModel { get; }
        public TankView TankView { get; }


        public TankModel GetModel()
        {
            return TankModel;
        }


        public void Fire(Transform bulletTransform, float bulletDamange)
        {
            TankService.Instance.Fire(bulletTransform, bulletDamange);
        }

    }
}
