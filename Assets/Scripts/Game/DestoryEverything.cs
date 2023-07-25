
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DestoryEverything : MonoSingletonGeneric<DestoryEverything>
{
    public PlayerTankView PlayerTank;
    public List<EnemyTankView> EnemyTanks;
    public GameObject[] EnviromentItems;
    public ParticleSystem TankExplosion;
    public int timeForTankExplosion = 2000;



    public async void DestroyEverythingInGame()
    {
        await Task.Delay(500);
        DestroyGameObject(PlayerTank.gameObject);
        foreach (EnemyTankView EnemyTank in EnemyTanks)
        {
            DestroyGameObject(EnemyTank.gameObject);
        }
        foreach(GameObject item in EnviromentItems)
        {
            Destroy(item);
            await Task.Delay(1000);
        }
    }

    private async void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
        ParticleSystem explosion = Instantiate<ParticleSystem>(TankExplosion, gameObject.transform.position, TankExplosion.transform.rotation);
        explosion.Play();
        await Task.Delay(timeForTankExplosion);
        Destroy(explosion.gameObject);
    }
}
