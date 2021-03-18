using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : TankAI
{
    public NormalEnemySpawnManagerScriptableObject normalSpawnManagerValues;
    public override void Start()
    {
        base.Start();

        Debug.Log(fireTransform);
    }
    public override void Fire(float fireForce)
    {

        base.Fire(normalSpawnManagerValues.fireForce);

    }
    public override void StopFiring()
    {
        base.StopFiring();
    }
    public override void StartFiring(float interval)
    {
        base.StartFiring(normalSpawnManagerValues.numberOfShellsPerSeconds);
    }

}