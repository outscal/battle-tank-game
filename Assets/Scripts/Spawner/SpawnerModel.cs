using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerModel
{
    public  SpawnerModel(Vector3 spawnPos)
    {
        SpawnPos = spawnPos;
    }

    public Vector3 SpawnPos { get; }
  
}
