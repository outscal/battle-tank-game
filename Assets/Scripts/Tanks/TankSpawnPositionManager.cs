using Singleton;
using System.Collections.Generic;
using UnityEngine;
using Tank;

public class TankSpawnPositionManager : MonoSingletonGeneric<TankSpawnPositionManager>
{
    [SerializeField]
    private Transform tankSpawnPointsHolder;
    [SerializeField]
    private float spawnRange;
    private List<Transform> tankSpawnPoints = new List<Transform>();

    private void Awake()
    {
        base.Awake();
        LoadTankSpawnPoints();
    }

    private void LoadTankSpawnPoints()
    {
        for (int i = 0; i < tankSpawnPointsHolder.childCount; i++)
        {
            tankSpawnPoints.Add(tankSpawnPointsHolder.GetChild(i));
        }
    }

    public Transform GetEmptySpawnPosition()
    {
        List<Transform> tempSpawnPoints = new List<Transform>();

        for (int i = 0; i < tankSpawnPoints.Count; i++)
        {
            tempSpawnPoints.Add(tankSpawnPoints[i]);
        }

        while (tempSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, (int)tempSpawnPoints.Count);

            if (CheckIfPositionIsEmpty(tempSpawnPoints[randomIndex].position))
            {
                return tempSpawnPoints[randomIndex];
            }
            else
            {
                tempSpawnPoints.Remove(tempSpawnPoints[randomIndex]);
            }
        }
        return null;
    }

    private bool CheckIfPositionIsEmpty(Vector3 pos)
    {
        int i = 0;
        List<TankController> tanks = TankService.Instance.createdTanks;
        for (i = 0; i < tanks.Count; i++)
        {
            if (Vector3.Distance(tanks[i].transform.position, pos) < spawnRange)
            {
                break;
            }
        }
        return i == tanks.Count;
    }

}
