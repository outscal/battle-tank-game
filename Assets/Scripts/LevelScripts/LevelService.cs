using System.Collections;
using UnityEngine;
using BattleTank.Enemy;
using BattleTank.PlayerCamera;

public class LevelService : GenericSingleton<LevelService>
{
    [SerializeField] GameObject[] entities;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] CameraController cameraController;
    public IEnumerator DestroyLevel()
    {
        StartCoroutine(cameraController.ZoomOut());
        yield return StartCoroutine(EnemyService.Instance.DestroyAllEnemies());
        yield return StartCoroutine(DestroyEnvironment());
    }
    public IEnumerator DestroyEnvironment()
    {
        foreach (GameObject item in entities)
        {
            yield return StartCoroutine(DestroyEntity(item));
        }
    }
    IEnumerator DestroyEntity(GameObject entity)
    {
        foreach (Transform item in entity.GetComponentsInChildren<Transform>())
        {
            if (item == entity.transform)
                continue;
            if (item.childCount != 0)
                continue;
            Vector3 pos = item.position;
            Destroy(item.gameObject);
            StartCoroutine(ExplosionEffect(pos));
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator ExplosionEffect(Vector3 pos)
    {
        ParticleSystem particleSystem = GameObject.Instantiate<ParticleSystem>(explosionEffect, pos, Quaternion.identity);
        particleSystem.Play();
        yield return new WaitForSeconds(2f);
        Destroy(particleSystem.gameObject);
    }
}
