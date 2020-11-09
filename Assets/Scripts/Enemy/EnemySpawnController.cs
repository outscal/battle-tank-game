using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoSingletonGeneric<EnemySpawnController>
{
    private int enemyCount = 5;
    private bool bossSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        MobSpawn();
    }

    private void MobSpawn()
    {
        for (int i = 1; i <= enemyCount; i++) {
            TankProvider.Instance.SpawnMob();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount == 0 && !bossSpawn)
        {
            TankProvider.Instance.SpawnBoss();
            bossSpawn = true;
        }
        else if (bossSpawn) { }
        else { enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; }
    }
}
