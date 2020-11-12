using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankProvider : MonoSingletonGeneric<TankProvider>
{

    // Start is called before the first frame update
    [SerializeField]
    private GameObject Tank;
    [SerializeField]
    private TankType mobTank;
    [SerializeField]
    private TankType bossTank;
    [SerializeField]
    private GameObject tankExplosion;

 
    
    public void SpawnMob() {
        GameObject enemy = Instantiate(Tank, new Vector3(UnityEngine.Random.Range(-48, 48), 0, UnityEngine.Random.Range(-48, 47)), transform.rotation);
        Renderer[] rend = enemy.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rend.Length; i++) rend[i].material.color = Color.red;
        enemy.tag = "Enemy";
        enemy.layer = 12;
        EnemyController ec = enemy.AddComponent<EnemyController>();
        ec.hp = mobTank.getHP();
        ec.payrollSpeed = mobTank.getSpd();
        ec.dmg = mobTank.getDmg();
        
    }

    public void SpawnBoss()
    {
        GameObject boss = Instantiate(Tank, new Vector3(UnityEngine.Random.Range(-48, 48), 0, UnityEngine.Random.Range(-48, 47)), transform.rotation);
        Renderer[] rend = boss.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rend.Length; i++) rend[i].material.color = Color.black;
        boss.transform.localScale *=3;
        boss.tag = "BossEnemy";
        boss.layer = 12;
        EnemyController ec = boss.AddComponent<EnemyController>();
        ec.hp = bossTank.getHP();
        ec.payrollSpeed = bossTank.getSpd();
        ec.dmg = bossTank.getDmg();
    }

        public void Boom(Transform t)
    {
        GameObject explosion = Instantiate(tankExplosion, t.position, t.rotation);
        explosion.transform.localScale *= 3f;
        Destroy(explosion, 2f);
    }
}
