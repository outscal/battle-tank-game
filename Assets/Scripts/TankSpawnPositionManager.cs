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
    public List<Transform> tankSpawnPoints = new List<Transform>();
    public List<GameObject> createdTanks = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < tankSpawnPointsHolder.childCount; i++)
        {
            tankSpawnPoints.Add(tankSpawnPointsHolder.GetChild(i));
        }
    }

    public void AddTank(GameObject setTank)
    {
        createdTanks.Add(setTank);
    }

    public Vector3 GetEmptySpawnPosition()
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
                return tempSpawnPoints[randomIndex].position;
            }
            else
            {
                tempSpawnPoints.Remove(tempSpawnPoints[randomIndex]);
            }
        }
        return Vector3.zero;
    }

    private bool CheckIfPositionIsEmpty(Vector3 pos)
    {
        int i = 0;
        TankController[] tanks = GameObject.FindObjectsOfType<TankController>();
        if (tanks.Length > 0)
        {
            for (i = 0; i < tanks.Length; i++)
            {
                if (Vector3.Distance(tanks[i].transform.position, pos) < spawnRange)
                {
                    break;
                }
            }
        }
        return i == createdTanks.Count;
    }

}
