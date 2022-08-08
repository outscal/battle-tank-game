using EnemyTankServices;
using GlobalServices;
using UIServices;
using UnityEngine;

namespace GameplayServices
{
    // Handles difficulty level of game and number of enemies to be spawnd per wave.
    public class WaveManager : MonoSingletonGeneric<WaveManager>
    {
        [SerializeField] private int tankSpawnDelay = 3;

        private int currentWave = 0;
        private bool b_IsGameOver = false;
        private bool b_IsGamePaused = false;
        private bool b_IsWaveCompleted = true;

        private void Start()
        {
            EventService.Instance.OnGameOver += GameOver;
            EventService.Instance.OnGamePaused += GamePaused;
            EventService.Instance.OnGameResumed += GameResumed;
            SpawnWave();
        }

        private void OnDisable()
        {
            EventService.Instance.OnGameOver -= GameOver;
            EventService.Instance.OnGamePaused -= GamePaused;
            EventService.Instance.OnGameResumed -= GameResumed;
        }

        // To start next wave.
        public void SpawnWave()
        {
            // Start next wave only when game is not over and previous wave is complete.
            if (!b_IsGameOver && b_IsWaveCompleted)
            {
                b_IsWaveCompleted = false;
                currentWave++;

                EventService.Instance.InvokeOnWaveSurvivedEvent();

                // Displays wave number.
                UIHandler.Instance.ShowDisplayText("Wave " + currentWave.ToString(), 3f);

                // Number of enemies to be spawned in current wave.
                float enemiesToBeSpawned = Mathf.Pow(2, (currentWave - 1));
                SpawnEnemy(enemiesToBeSpawned);
            }
        }

        // To spawn required number of enemy tanks.
        public async void SpawnEnemy(float enemyCount)
        {
            for(int i=0; i < enemyCount; i++)
            {
                // To add delay in emeny spawning.
                await new WaitForSeconds(tankSpawnDelay + 1);

                // Don't spawn enemy if game is paused. 
                // To ensure only 3 enemies are present at a time in scene.
                if(EnemyTankService.Instance.enemyTanks.Count > 2 || b_IsGamePaused)
                {
                    i--;
                }
                else
                {       
                    // Spawns random type of enemy tank.
                    int rand = Random.Range(0, EnemyTankService.Instance.enemyTankList.enemies.Length);
                    EnemyTankService.Instance.CreateEnemyTank((EnemyType)rand);
                }
            }

            b_IsWaveCompleted = true;
        }

        public int GetCurrentWave()
        {
            return currentWave;
        }

        private void GameOver()
        {
            b_IsGameOver = true;
        }

        private void GamePaused()
        {
            b_IsGamePaused = true;
        }

        private void GameResumed()
        {
            b_IsGamePaused = false;
        }
    }
}
