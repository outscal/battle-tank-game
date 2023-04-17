using UnityEngine;

namespace BattleTank.Services
{
    public class GameService : MonoBehaviour
    {
        private void Awake()
        {
            DestructionService.Instance.LoadEnvironment();
            DestructionService.Instance.SetCoroutineNull();
            UIService.Instance.DeactivateGameOverPanel();
            UIService.Instance.SetTankSelectionUI();
        }
        
        public void StartLevel()
        {
            UIService.Instance.ActivateStartingUI();
            EnemyTankService.Instance.SpawnEnemyTanks();
        }
    }
}