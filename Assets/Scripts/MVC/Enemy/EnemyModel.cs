using System.Drawing;
using UnityEngine;

public class EnemyModel 
{
    private EnemyController enemyController;
    private float speed;
    private float rotation;
    public TankTypeEnum tankType;
    public Color color;

    public void SetEnemyController(EnemyController _enemycontroller)
    {
          enemyController = _enemycontroller;
    }
    
    
}
