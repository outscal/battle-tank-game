using UnityEngine;

using Generic;
using System.Collections.Generic;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        
        public Transform TankParent;

        public List<TankScriptableObj> tankScriptableObjs;

        private TankView TankPrefab;

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            for (int i = 0; i < tankScriptableObjs.Count; i++)
            {
                SpawnTank(i);
            }
            
        }

        void SpawnTank(int tankIndex)
        {
            TankModel tankModel = new TankModel(tankScriptableObjs[tankIndex]);
            TankPrefab = tankModel.M_TankView;
            TankController TankObj = new TankController(tankModel, TankPrefab, TankParent);
        }

    }
}
