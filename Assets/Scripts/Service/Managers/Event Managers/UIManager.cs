using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using Tank.EventService;

    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject AcheivementPanel;
        [SerializeField] private GameObject UpdatePanel;
        [SerializeField] private TextMeshProUGUI Ammo;
        [SerializeField] private TextMeshProUGUI Score;
        [SerializeField] private TextMeshProUGUI Kills;
        [SerializeField] private TextMeshProUGUI WaveStatus;
        [SerializeField] private TextMeshProUGUI Achievement;
        [SerializeField] private GameObject GameOverPanel;
        [SerializeField] private TextMeshProUGUI GameStatus;
        [SerializeField] private GameObject GamePausePanel;
        [SerializeField] private int TotalBulletCount = 10;
        private int KillCount = 0;
        private int score = 0;
        private void Start()
        {
            UpdatePanel.SetActive(true);
            EventManagement.Instance.OnPlayerShoot += BulletCount;
            EventManagement.Instance.OnEnemyDeath += EnemyDeath;
            EventManagement.Instance.OnPlayerDeath += PlayerDeath;
            EventManagement.Instance.OnWaveComplete += WaveComplete;
        }
        private void OnDisable()
        {
            EventManagement.Instance.OnPlayerShoot -= BulletCount;
            EventManagement.Instance.OnEnemyDeath -= EnemyDeath;
            EventManagement.Instance.OnPlayerDeath -= PlayerDeath;
            EventManagement.Instance.OnWaveComplete -= WaveComplete;
        }
        public void BulletCount()
        {
            TotalBulletCount -= 1;
            Ammo.text = $"Ammo [{TotalBulletCount}]";
        }
        public void EnemyDeath()
        {
            KillCount++;
            score += 50;
            Score.text = $"Score: {score}";
            Kills.text = $"Kill: {KillCount}";
        }
        public async void WaveComplete(int wave)
        {
            AcheivementPanel.SetActive(true);
            WaveStatus.text = wave + " Wave Complete";
            await Task.Delay(10);
            AcheivementPanel.SetActive(false);
            if(wave == 6)
            {
                GameOverPanel.SetActive(true);
                GameStatus.text = "Level Complete";
            }

        }
        public void PlayerDeath()
        {
            GameOverPanel.SetActive(true);
            GameStatus.text = "Game Over";
        }
        public IEnumerator ShowAchievement(string achievement)
        {
            AcheivementPanel.SetActive(true);
            Achievement.enabled = true;
            Achievement.text = achievement;
            
            yield return new  WaitForSeconds(2f);
            Achievement.enabled = false;
            AcheivementPanel.SetActive(false);
        }
        
    }

