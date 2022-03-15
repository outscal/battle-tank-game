using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button playBtn;
        [SerializeField] Button quitBtn;
        [SerializeField] Button startBtn;
        [SerializeField] AudioSource source;
        public GameObject infoText;

        void Start()
        {
            playBtn.onClick.AddListener(Play);
            quitBtn.onClick.AddListener(Exit);
            startBtn.onClick.AddListener(Startgame);
        }
        public void Play()
        {
            infoText.gameObject.SetActive(true);
        }
        public void Startgame()
        {
            SceneManager.LoadScene(2);
        }
        public void Exit()
        {
            Application.Quit();
        }
        public void PlaySound()
        {
            source.Play();
        }
    }

}
