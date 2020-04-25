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
        public TankScriptableObjectList tankList;
        public TankScriptableObject tankScriptable { get; private set; }
        private List<TankController> tanks = new List<TankController>();
        private Coroutine respawn;

        private void Start()
        {
            CreateTank(); // if you want multiple players call CreateTanks() method mutltiple times

            //tankModel do not have Mono as parent so we have to pass it using contructor's returned object
            //as view has Mono as Parent we can drag drop it via inspector
        }
        public void CreateTank()
        {
            int rand = Random.Range(0, tankList.tanks.Length);
            tankScriptable = tankList.tanks[rand];

            TankModel tankModel = new TankModel(tankScriptable, tankList);
            TankController controller = new TankController(tankModel, tankScriptable.tankView);
            tanks.Add(controller);
        }

        public void DestroyTank(TankController tank)
        {
            tank.DestroyController();
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] == tank)
                {
                    tanks[i] = null;
                    tanks.Remove(tank);
                }
            }
            if (respawn == null)
                StartCoroutine(RespawnTank());
        }
        private IEnumerator RespawnTank()
        {
            yield return new WaitForSeconds(4f);
            CreateTank();
            if (respawn != null)
            {
                StopCoroutine(respawn);
                respawn = null;
            }
        }
    }
}