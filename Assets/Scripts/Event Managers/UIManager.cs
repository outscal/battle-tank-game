using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UIManager
{
    public class UIManager : Singleton<UIManager>
    {
        public GameObject lossPanel;
        public GameObject winPanel;
        private void Start()
        {
            EventManagement.Instance.OnEnemyDeath += ShowDeathScreen;
            EventManagement.Instance.OnPlayerDeath += ShowPlayerDeath;
        }
        private void ShowDeathScreen()
        {
            
            winPanel.SetActive(true);
        }
        private void ShowPlayerDeath() 
        {
            lossPanel.SetActive(true);
        }
        public void OnPlayButtonPress()
        {
            SceneManager.LoadScene(0);
        }
        public void OnRetryButtonPress()
        {
            SceneManager.LoadScene(0);
        }
        private void OnDisable()
        {
            EventManagement.Instance.OnEnemyDeath-= ShowDeathScreen;
            EventManagement.Instance.OnPlayerDeath-= ShowPlayerDeath;

        }
    }
}