using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{

    public EnemyModel(EnemyScriptaleObject enemyScriptableObject)
    {
        EnemyType = enemyScriptableObject.EnemyType;
        EnemySpeed = enemyScriptableObject.EnemySpeed;
       // EnemyRotationSpeed = enemyScriptableObject.EnemyRotationSpeed;
        WayPoints = enemyScriptableObject.WayPoints;
        



    }

    public EnemyType EnemyType { get; }
    public int EnemySpeed {get;}

  //  public int EnemyRotationSpeed { get; }

    public Transform[] WayPoints { get; }

   


}
