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
        public void DestroyTank(TankController tank)
        {
            StartCoroutine(RespawnTankAfterDelay(tank));
        }

        public IEnumerator RespawnTankAfterDelay(TankController tank)
        {
            Debug.Log("Resetting");
            tank.gameObject.SetActive(false);
            yield return new WaitForSeconds(5f);
            Debug.Log("Resetting tsnk");
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
