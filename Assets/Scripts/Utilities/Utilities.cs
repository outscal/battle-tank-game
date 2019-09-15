using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBattleUtilities
{
    public static Vector3 GetAPointInRange(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }
}
