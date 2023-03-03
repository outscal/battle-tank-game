using TankBattle.TankService.PlayerTank;
using UnityEngine;

namespace TankBattle
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputReader _input;
        [SerializeField] private PlayerService _playerService;
        [SerializeField] private GameObject pauseMenu;

        private bool _isPaused = false;

        private void Start()
        {
            //_playerService.CreateTank();
            _input.PauseEvent += HandlePause;
            _input.ResumeEvent += HandleResume;
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