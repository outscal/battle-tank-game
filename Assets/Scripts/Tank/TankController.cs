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
    }
}
