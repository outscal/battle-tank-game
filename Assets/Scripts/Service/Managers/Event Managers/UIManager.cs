using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
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
        private int TotalBulletCount = 10;
        private int KillCount = 0;
        private int score = 0;
        private void Start()
        {
            UpdatePanel.SetActive(true);
            EventManagement.OnPlayerShoot += BulletCount;
            EventManagement.OnEnemyDeath += EnemyDeath;
            EventManagement.OnPlayerDeath += PlayerDeath;
            EventManagement.OnWaveComplete += WaveComplete;
        }
        private void OnDisable()
        {
            EventManagement.OnPlayerShoot -= BulletCount;
            EventManagement.OnEnemyDeath -= EnemyDeath;
            EventManagement.OnPlayerDeath -= PlayerDeath;
            EventManagement.OnWaveComplete -= WaveComplete;
        }
        public void BulletCount()
        {
            TotalBulletCount -= 1;
            Debug.Log("Current Bullet" + 1);
            Ammo.text = TotalBulletCount+"";
        }
        public void EnemyDeath()
        {
            KillCount++;
            score += 50;
            Score.text = score+"";
            Kills.text = KillCount+"";
        }
        public void WaveComplete(int wave)
        {
            //show wave complete panel
            AcheivementPanel.SetActive(true);
            Achievement.enabled = true;
            WaveStatus.text = wave + " Wave Complete";
            //yield return new WaitForSeconds(1.0f);
            
            Achievement.enabled = false;
            AcheivementPanel.SetActive(true);
            if(wave == 6)
            {
                //game complete
                DestroySequence.Instance.GameComplete(this.transform);
            }

        }
        public void PlayerDeath()
        {
            DestroySequence.Instance.PlayerDeath();
        }
        public IEnumerator ShowAchievement(string achievement)
        {
            AcheivementPanel.SetActive(true);
            Achievement.enabled = true;
            Achievement.text = achievement;
            yield return new WaitForSeconds(1.0f);
            Achievement.enabled = false;
            AcheivementPanel.SetActive(true);
        }
        
    }

