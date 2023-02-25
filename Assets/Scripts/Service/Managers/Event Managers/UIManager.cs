using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Tank.EventService;

    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject AcheivementPanel;
        [SerializeField] private TextMeshProUGUI bulletCount;
        private int TotalBulletCount = 10;
        private void Start()
        {
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
            bulletCount.text = TotalBulletCount+"";
        }
        public void EnemyDeath()
        {
            // some enemy wave logic
            //manage enemy remaining
        }
        public void WaveComplete(int wave)
        {
            //show wave complete panel
            if(wave == 6)
            {
                //game complete
                //DestroySequence.Instance.WaveComplete(this.transform);
            }
        }
        public void PlayerDeath()
        {
            DestroySequence.Instance.PlayerDeath();
        }
        public void ShowAchievement(string achievement)
        {
            AcheivementPanel.SetActive(true);
            AcheivementPanel.GetComponentInChildren<TextMeshProUGUI>().text = achievement;
        }
        
    }

