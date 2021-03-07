using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GenericSingletonClass<GameManager>
{
    public GameObject terrain;
    public GameObject canvas;
    public GameObject playerSpawner;
    public GameObject enemySpawner;
    public GameObject sound;
    public GameObject shells;
    public GameObject cam;

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

        yield return new WaitForSeconds(1f);

        StartCoroutine(DestroyCanvas());

        yield return new WaitForSeconds(1f);

        StartCoroutine(DestroyTerrain());

        yield return new WaitForSeconds(1f);

        StartCoroutine(DestroyAudio());
    }

    IEnumerator DestroyEnemies()
    {
        // Move the instantiated explosion prefab to the tank's position and turn it on.
        EnemyController.Instance.m_ExplosionParticles.transform.position = transform.position;
        EnemyController.Instance.m_ExplosionParticles.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        EnemyController.Instance.m_ExplosionParticles.gameObject.SetActive(false);
        EnemyController.Instance.gameObject.SetActive(false);

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

    void Update()
    {
        if (TankController.Instance.m_Dead)
            StartCoroutine(DelayDeath());
    }
}
