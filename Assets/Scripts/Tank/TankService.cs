using UnityEngine;

using Generic;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankView TankPrefab;
        public Transform TankParent;

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            TankModel tankModel = new TankModel(5, 100f, 180f, 1, 0.2f, 15f, KeyCode.F);
            TankController TankObj = new TankController(tankModel, TankPrefab, TankParent);
        }

    }
}
