using UnityEngine;
using System.Collections.Generic;
public class EnemyModel
{
    List<Vector3> patrolPoints;
    public EnemyModel(List<Vector3> spawnPoints)
    {
        patrolPoints = spawnPoints;
    }

    public Vector3 GetPoint(int index)
    {
        return patrolPoints[index];
    }

    public int GetCount()
    {
        return patrolPoints.Count;
    }

}
