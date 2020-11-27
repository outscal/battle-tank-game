using Singleton;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameEvents;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private TankController playerTank;
        public List<TankController> createdTanks;
        
        public TankController CreatePlayer()
        {
            Transform randomTransform = TankSpawnPositionManager.Instance.GetEmptySpawnPosition();
            TankController tankControl = Instantiate(playerTank, randomTransform.position, Quaternion.identity);
            createdTanks.Add(tankControl);
            return tankControl;
        }
        public void DestroyTank(TankController tank)
        {
            if (tank != playerTank)
            {
                GameEventsManager.Instance.InvokeEnemyKilledEvent();
            }
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
            Transform randomTransform = TankSpawnPositionManager.Instance.GetEmptySpawnPosition();
            tank.transform.position = randomTransform.position;
            tank.transform.eulerAngles = randomTransform.eulerAngles;
            tank.ResetTankValues();
        }

        public void AddTank(TankController tank)
        {
            createdTanks.Add(tank);
        }
    }
}
