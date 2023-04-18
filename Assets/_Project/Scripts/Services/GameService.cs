using BattleTank.GenericSingleton;

namespace BattleTank.Services
{
    public class GameService : GenericSingleton<GameService>
    {
        protected override void Awake()
        {
            base.Awake();
            StartGame();
            SoundService.Instance.PlayMusic(Enum.Sounds.BackgroudMusic);
        }
        public void StartGame()
        {
            DestructionService.Instance.LoadEnvironment();
            DestructionService.Instance.SetCoroutineNull();
            UIService.Instance.DeactivateGameOverPanel();
            UIService.Instance.SetTankSelectionUI();
            ScoreService.Instance.ResetScore();
        }
        
        public void StartLevel()
        {
            UIService.Instance.ActivateStartingUI();
            EnemyTankService.Instance.SpawnEnemyTanks();
        }
    }
}