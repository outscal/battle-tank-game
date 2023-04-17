using UnityEngine;

namespace BattleTank.Services
{
    public class GameService : MonoBehaviour
    {
        private void Awake()
        {
            DestructionService.Instance.LoadEnvironment();
            UIService.Instance.SetStartingDisplayPanel();
            DestructionService.Instance.SetCoroutineNull();
        }
        
        private void Start()
        {
            PlayerTankService.Instance.SpawnPlayerTank();
            EnemyTankService.Instance.SpawnEnemyTanks();
        }
    }
}