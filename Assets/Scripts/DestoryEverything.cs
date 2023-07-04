
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



    public async void Destroy()
    {
        await Task.Delay(500);
        Destroy(PlayerTank.gameObject);
        ParticleSystem explosion = Instantiate<ParticleSystem>(TankExplosion, PlayerTank.transform.position, TankExplosion.transform.rotation);
        explosion.Play();
        await Task.Delay(timeForTankExplosion);
        Destroy(explosion.gameObject);
        foreach (EnemyTankView EnemyTank in EnemyTanks)
        {
            Destroy(EnemyTank.gameObject);
            explosion = Instantiate<ParticleSystem>(TankExplosion, EnemyTank.transform.position, TankExplosion.transform.rotation);
            explosion.Play();
            await Task.Delay(timeForTankExplosion);
            Destroy(explosion.gameObject);
        }
        foreach(GameObject item in EnviromentItems)
        {
            Destroy(item);
            await Task.Delay(1000);
        }
    }
}
