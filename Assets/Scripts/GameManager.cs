using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GameManager : GenericSingletonClass<GameManager>
{
    public GameObject terrain;
    public GameObject canvas;
    public GameObject playerSpawner;
    public GameObject enemySpawner;
    public GameObject sound;
    public GameObject shells;
    public GameObject cam;
    public GameObject playerTank;
    //public GameObject enemyTank;
    public Text txt;
    public Text scoreTxt;
    public int scoreCounter;

    UnityEvent healthEvent, scoreEvent, shellsFiredAchievementEvent, killsAchievementEvent;

    IEnumerator DelayDeath()
    {
        TankController.Instance.m_ExplosionParticles.Play();

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        TankController.Instance.m_ExplosionParticles.transform.position = transform.position;
        TankController.Instance.m_ExplosionParticles.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        TankController.Instance.m_ExplosionParticles.gameObject.SetActive(false);
        TankController.Instance.gameObject.SetActive(false);
        Destroy(playerSpawner);

        yield return new WaitForSeconds(1f);

        StartCoroutine(DestroyEnemies());
        StartCoroutine(DestroyCanvas());
        StartCoroutine(DestroyTerrain());
        StartCoroutine(DestroyAudio());
    }

    IEnumerator DestroyEnemies()
    {
        // Move the instantiated explosion prefab to the tank's position and turn it on.
        //EnemyController.Instance.m_ExplosionParticles.transform.position = transform.position;
        //EnemyController.Instance.m_ExplosionParticles.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        //EnemyController.Instance.m_ExplosionParticles.gameObject.SetActive(false);


        if (Spawner.Instance.enemyTankList == null)
        {
            foreach (GameObject enemyTanks in GameObject.FindGameObjectsWithTag("Enemy"))
            {

                Spawner.Instance.enemyTankList.Add(enemyTanks);
            }
        }
        else
            Spawner.Instance.enemyTank = GameObject.FindGameObjectWithTag("Enemy");

        foreach (GameObject go in Spawner.Instance.enemyTankList)
        {
            Destroy(go);
        }

        Destroy(enemySpawner);
    }
    IEnumerator DestroyCanvas()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(canvas);
    }
    IEnumerator DestroyTerrain()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(terrain);
    }
    IEnumerator DestroyAudio()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(sound);
    }
    IEnumerator DestroyCamera()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(GetComponent<Camera>());
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(2f);
        txt.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (TankController.Instance.m_Dead)
            StartCoroutine(DelayDeath());

        if (Spawner.Instance.counter == 10 && killsAchievementEvent != null)
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

    }

    private void Start()
    {
        if (healthEvent == null)
            healthEvent = new UnityEvent();

        healthEvent.AddListener(health);

        if (scoreEvent == null)
            scoreEvent = new UnityEvent();

        scoreEvent.AddListener(score);

        if (shellsFiredAchievementEvent == null)
            shellsFiredAchievementEvent = new UnityEvent();

        shellsFiredAchievementEvent.AddListener(a1);

        if (killsAchievementEvent == null)
            killsAchievementEvent = new UnityEvent();

        killsAchievementEvent.AddListener(a2);
    }

    void a1()
    {
        txt.GetComponent<Text>().enabled = true;
        txt.text = "Achievement unlocked! \r\n 20 shots fired";
        StartCoroutine(DisableText());

    }

    void a2()
    {
        txt.GetComponent<Text>().enabled = true;
        txt.text = "Achievement unlocked! \r\n 20 Kills";
        StartCoroutine(DisableText());
    }

    void health() { }
    void score() 
    { 
        scoreTxt.text = scoreCounter.ToString();
    }

}
