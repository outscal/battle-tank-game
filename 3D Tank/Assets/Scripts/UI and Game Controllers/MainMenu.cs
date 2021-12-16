using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] Button quitBtn;

    public void Play()
    {
      SceneManager.LoadScene("Game");
    }

  public void Exit()
    {
      Application.Quit();
    }
}
