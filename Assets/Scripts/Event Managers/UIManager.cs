using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Tank.EventService;
namespace Tank.EventService
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject AcheivementPanel;
        [SerializeField] private TextMeshProUGUI bulletCount;
        private int TotalBulletCount = 10;
        private void OnEnable()
        {
            EventManagement.Instance.OnPlayerShoot += BulletCount;
            EventManagement.Instance.OnEnemyDeath += EnemyDeath;
            EventManagement.Instance.OnPlayerDeath += PlayerDeath;
        }
        public void BulletCount(int count)
        {
            TotalBulletCount -= count;
            Debug.Log("Current Bullet" + 1);
            bulletCount.text = TotalBulletCount+"";
        }
        public void EnemyDeath(int count)
        {
            // some enemy wave logic
            DestroySequence.Instance.WaveComplete(this.transform);
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
        private void OnDisable()
        {
            EventManagement.Instance.OnPlayerShoot -= BulletCount;
            EventManagement.Instance.OnEnemyDeath -= EnemyDeath;
            EventManagement.Instance.OnPlayerDeath -= PlayerDeath;
        }
    }

}