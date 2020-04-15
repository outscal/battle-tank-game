using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController 
{

    public SpawnerController(SpawnerModel spawnerModel, SpawnerView spawnerPrefab )
    {
        SpawnerModel = spawnerModel;
        SpawnerPrefab = GameObject.Instantiate<SpawnerView>(spawnerPrefab);
        spawnerPrefab.setPosition(SpawnerModel);
    }

    public SpawnerModel SpawnerModel { get; }
    public SpawnerView SpawnerPrefab { get; }
}
