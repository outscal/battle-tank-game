using UnityEngine;

namespace TankBattle
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Tank.PlayerTank.InputSystem.InputReader _input;
        [SerializeField] private Tank.PlayerTank.PlayerService playerService;
        [SerializeField] private GameObject pauseMenu;


        private void Start()
        {
            _input.PauseEvent += HandlePause;
            _input.ResumeEvent += HandleResume;
        }

        private void OnDisable()
        {
            _input.PauseEvent -= HandlePause;
            _input.ResumeEvent -= HandleResume;
        }

        private void HandlePause()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        private void HandleResume()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

    }
}