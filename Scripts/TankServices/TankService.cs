using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using BulletServices;
using TankSO;


namespace TankServices
{
    public class TankService : GenericSingleton<TankService>
    {
        public TankScriptableObjectList tankTypes;
        private TankScriptableObject tankScriptable;

        private void Start()
        {
            CreateTank(0);
            CreateTank(1);
            CreateTank(2);

            //tankModel do not have Mono as parent so we have to pass it using contructor's returned object
            //as view has Mono as Parent we can drag drop it via inspector
        }
        public void CreateTank(int i)
        {
            int rand = Random.Range(0, tankTypes.tanks.Length);

            tankScriptable = tankTypes.tanks[i];


            TankModel tankModel = new TankModel(tankScriptable);
            TankController controller = new TankController(tankModel, tankScriptable.tankView);
        }
    }
}