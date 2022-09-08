using System.Drawing;
using UnityEngine;

public class EnemyModel 
{
    private EnemyController enemyController;
    private float speed;
    private float rotation;
    public TankTypeEnum tankType;
    
    public EnemyModel(TankScriptableObject tankScriptableObject)
    {
       tankType = tankScriptableObject.TankType;
       speed = tankScriptableObject.speed;
       rotation = tankScriptableObject.rspeed;
       
       
    }

    public void SetEnemyController(EnemyController _enemycontroller)
    {
          enemyController = _enemycontroller;
    }
    
    
}
