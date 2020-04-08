using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerService : MonoSingletonGeneric<SpawnerService>
{
    //private SpawnerModel[] model = new SpawnerModel[3];
    //public SpawnerView spawnerView;
    public Transform[] spawners;
    

    protected override void Awake()
    {
        base.Awake();
    }
     
    private void Start()
    {
        //for (int i = 0; i < spawners.Length; i++)
        //{
        //    model[i] = new SpawnerModel(spawners[i].transform.position);
        //    SpawnerController spawnerController = new SpawnerController(model[i], spawnerView);
        //    SpawnTanks(spawners[i]);
        //}
    }

    public void SpawnTanks(int tankNumber)
    {
        TankService.Instance.SpawnTankPrefab(spawners[tankNumber], tankNumber);
    }
}
