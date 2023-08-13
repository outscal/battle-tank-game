using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :GenericSingleTon<GameManager>
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pausePnael;
    private bool isGameOver = false;
    private bool GameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                GameIsPause();
            }
        }
        
        

    }
    public void GameOver()
    {
        if(isGameOver)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
    public void GameIsPause()
    {
         pausePnael.SetActive(true);
         Time.timeScale = 0f;
    }
  public void ResumeGame()
    {    
        pausePnael.SetActive(false);
        Time.timeScale = 1f;
    }
  public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}
