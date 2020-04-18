using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleService : MonoSingletonGeneric<ParticleService>
{
    public ParticleSystem[] particleEffect;

    public void CreateBulletExplosion(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Instantiate(particleEffect[0], spawnPosition, spawnRotation);
        particleEffect[0].Play();

    }
    public void CreateTankExplosion(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Instantiate(particleEffect[1], spawnPosition, spawnRotation);
        particleEffect[1].Play();
    }

}
