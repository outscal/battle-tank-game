using UnityEngine;

public class EnemyModel
{
    public EnemyTankType EnemyTankType { get; set; }
    public float Speed { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
  



    public EnemyModel(EnemyTankScriptableObject enamyTankScriptableObject)
    {
        EnemyTankType = enamyTankScriptableObject.EnemyTankType;
        Speed = enamyTankScriptableObject.Speed;
        Health = enamyTankScriptableObject.Health;



    }

    public EnemyModel(EnemyTankType eTankType, float speed, float health, float damage)
    {
        Speed = speed;
        Health = health;
        EnemyTankType = eTankType;
        Damage = damage;

    }


}
