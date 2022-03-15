using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Pause
{
    public class PauseMenuController : GenericSingleton<PauseMenuController>
    {
        public GameStates state;
        public AudioSource source;
        public AudioSource portalSound;

        [Header("Pause Menu")]
        public Button[] pauseMenuButtons;

        [Header("Game Won Menu")]
        public Button[] gameWinButtons;

        [Header("Game Lost Menu")]
        public Button[] gameOverButtons;

        public GameObject[] UI;
        public GameObject portal;
        public GameObject portalMessage;

        private void Start()
        {
            state = GameStates.RunningState;
            pauseMenuButtons[2].onClick.AddListener(RestartLevel1);
        }
        void Update()
        {
            pauseMenuButtons[0].onClick.AddListener(EnablePauseMenu);
            pauseMenuButtons[1].onClick.AddListener(DisablePauseMenu);
            pauseMenuButtons[3].onClick.AddListener(EnableMainMenu);

            gameWinButtons[0].onClick.AddListener(EnableMainMenu);

            //gameOverButtons[0].onClick.AddListener(EnableMainMenu);


            if (TankController.Instance.isTankDead)
            {
                state = GameStates.PauseState;
                UI[2].gameObject.SetActive(true);
            }

            if(EnemyTankService.Instance.activatePortal)
            {
                portal.gameObject.SetActive(true);
                portalSound.Play();
                EnablePortalMessage();
            }
        }

        public void EnablePortalMessage()
        {
            portalMessage.gameObject.SetActive(true);
        }
        private void EnablePauseMenu()
        {
            state = GameStates.PauseState;
            UI[0].gameObject.SetActive(true);
        }
        private void DisablePauseMenu()
        {
            state = GameStates.RunningState;
            UI[0].gameObject.SetActive(false);
        }
        public void RestartLevel1()
        {
            SceneManager.LoadScene(2);
            UI[0].gameObject.SetActive(false);
        }
        public void EnableMainMenu()
        {
            SceneManager.LoadScene(1);
        }
        public void PlayButtonSound()
        {
            source.Play();
        }
    }

}
