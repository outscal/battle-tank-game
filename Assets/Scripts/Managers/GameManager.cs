using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : GenericSingletonClass<GameManager>
{
    public GameObject terrain;
    public GameObject canvas;
    public GameObject enemySpawner;
    public GameObject sound;
    public GameObject shells;
    public GameObject cam;
    public GameObject playerTank;
    public GameObject enemyTankPrefab;
    public GameObject shellPrefab;
    public Text txt;
    public Text scoreTxt;
    public Text tanksLeftTxt;
    public GameObject tankExplosion;

    [HideInInspector]
    public int getNormalTanks, getMediumTanks, getHardTanks;
    [HideInInspector]
    public static int scoreCounter;

    UnityEvent healthEvent, scoreEvent, shellsFiredAchievementEvent, killsAchievementEvent, tanksLeftEvent;

    public Button playAgainBtn, backBtn;
    public GameObject gameOverPanel;


    IEnumerator DelayDeath()
    {
        if (TankController.Instance.isDead)
        {
            var tankExplosionGo = PoolManager.Instantiate(tankExplosion, TankController.Instance.gameObject.transform.position, TankController.Instance.gameObject.transform.rotation);
            // Play the particle system of the tank exploding.
            tankExplosionGo.GetComponent<ParticleSystem>().Play();
            // Play the tank explosion sound effect.
            tankExplosionGo.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1f);

            //TankController.Instance.gameObject.SetActive(false);
            //Destroy(TankController.Instance.gameObject);

            tankExplosionGo.GetComponent<ParticleSystem>().Stop();
            tankExplosionGo.GetComponent<AudioSource>().Stop();

            StartCoroutine(DisableEnemies());
            StartCoroutine(DisableGameUI());
            StartCoroutine(DisableTerrain());
            StartCoroutine(DisableAudio());

            StartCoroutine(ShowGameOverScreen());
        }
    }

    IEnumerator DisableEnemies()
    {
        yield return new WaitForSeconds(1f);

        if (EnemySpawner.Instance.allEnemyTankList == null)
        {
            foreach (GameObject enemyTanks in GameObject.FindGameObjectsWithTag("Enemy"))
            {

                EnemySpawner.Instance.allEnemyTankList.Add(enemyTanks);
            }
        }
        else
            //EnemySpawner.Instance.enemyTankPrefab = GameObject.FindGameObjectWithTag("Enemy");

            foreach (GameObject go in EnemySpawner.Instance.allEnemyTankList)
            {
                go.SetActive(false);
            }

        EnemySpawner.Instance.allEnemyTankList.Clear();

        enemySpawner.SetActive(false);

    }
    IEnumerator DisableGameUI()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject[] canvasUI = GameObject.FindGameObjectsWithTag("UI");
        foreach (GameObject go in canvasUI)
        {
            go.SetActive(false);
        }
    }
    IEnumerator DisableTerrain()
    {
        yield return new WaitForSeconds(0.5f);
        terrain.SetActive(false);
    }
    IEnumerator DisableAudio()
    {
        yield return new WaitForSeconds(0.5f);
        sound.SetActive(false);
    }
    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(2f);
        txt.GetComponent<Text>().enabled = false;
    }


    void RestartGame()
    {
        gameOverPanel.SetActive(false);

        SceneManager.LoadScene(1);

        TankController.Instance.gameObject.SetActive(true);
        
        enemySpawner.SetActive(true);

        List<GameObject> canvasComponents = new List<GameObject>();

        canvasComponents.Add(GameObject.FindGameObjectWithTag("UI"));
        canvasComponents.Add(GameObject.FindGameObjectWithTag("Image"));

        foreach (GameObject go in canvasComponents) 
        {
            go.SetActive(true);
        }

        terrain.SetActive(true);

        sound.SetActive(true);

        gameObject.GetComponent<TankController>().enabled = true;
        gameObject.GetComponent<GameManager>().enabled = true;
        gameObject.GetComponent<EnemySpawner>().enabled = true;
        

    }

    void BackToLobby()
    {
        SceneManager.LoadScene(0);
        gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        getNormalTanks = PlayerPrefs.GetInt("normalTanks");
        getMediumTanks = PlayerPrefs.GetInt("mediumTanks");
        getHardTanks = PlayerPrefs.GetInt("hardTanks");


        if (healthEvent == null)
            healthEvent = new UnityEvent();

        healthEvent.AddListener(Health);

        if (scoreEvent == null)
            scoreEvent = new UnityEvent();

        scoreEvent.AddListener(Score);

        if (tanksLeftEvent == null)
            tanksLeftEvent = new UnityEvent();

        tanksLeftEvent.AddListener(TanksLeft);

        if (shellsFiredAchievementEvent == null)
            shellsFiredAchievementEvent = new UnityEvent();

        shellsFiredAchievementEvent.AddListener(A1);

        if (killsAchievementEvent == null)
            killsAchievementEvent = new UnityEvent();

        killsAchievementEvent.AddListener(A2);

        PoolManager.SetNetPoolSize(enemyTankPrefab, 20);
        PoolManager.SetPoolSize(enemyTankPrefab, 10);

        PoolManager.SetNetPoolSize(shellPrefab, 10);
        PoolManager.SetPoolSize(shellPrefab, 5);

        Button playAgain = playAgainBtn.GetComponent<Button>();
        Button back = backBtn.GetComponent<Button>();
        playAgain.onClick.AddListener(RestartGame);
        back.onClick.AddListener(BackToLobby);


    }

    void Update()
    {
        if (TankController.Instance.isDead)
            StartCoroutine(DelayDeath());

        if (EnemySpawner.Instance.enemyCounter == 10 && killsAchievementEvent != null)
        {
            killsAchievementEvent.Invoke();
        }

        if (TankController.Instance.shellCounter == 20 && shellsFiredAchievementEvent != null)
        {
            shellsFiredAchievementEvent.Invoke();
        }
        if (scoreEvent != null)
        {
            scoreEvent.Invoke();
        }

        if (tanksLeftEvent != null) 
        {
            tanksLeftEvent.Invoke();
        }
    }

    void A1()
    {
        txt.GetComponent<Text>().enabled = true;
        txt.text = "Achievement unlocked! \r\n 20 shots fired";
        StartCoroutine(DisableText());

    }

    void A2()
    {
        txt.GetComponent<Text>().enabled = true;
        txt.text = "Achievement unlocked! \r\n 20 Kills";
        StartCoroutine(DisableText());
    }

    void Health() { }
    void Score()
    {
        scoreTxt.text = scoreCounter.ToString();
    }

    void TanksLeft() {
        tanksLeftTxt.text = EnemySpawner.Instance.allEnemyTankList.Count.ToString();
    }

}
