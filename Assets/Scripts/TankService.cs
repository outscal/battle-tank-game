using Singleton;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private TankController playerTank;
        public List<TankController> createdTanks;
        
        public TankController CreatePlayer()
        {
            TankController tankControl = Instantiate(playerTank, TankSpawnPositionManager.Instance.GetEmptySpawnPosition(), Quaternion.identity);
            createdTanks.Add(tankControl);
            return tankControl;
        }
        
       

        public IEnumerator RespawnTankAfterDelay(TankController tank)
        {
            tank.gameObject.SetActive(false);
            yield return new WaitForSeconds(5f);
            ResetTank(tank);
        }

        public void ResetTank(TankController tank)
        {
            tank.gameObject.SetActive(true);
            tank.transform.position = TankSpawnPositionManager.Instance.GetEmptySpawnPosition();
            tank.ResetTankValues();
        }

        public void AddTank(TankController tank)
        {
            createdTanks.Add(tank);
        }
    }
}
