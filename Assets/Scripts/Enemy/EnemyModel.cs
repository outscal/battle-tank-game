using UnityEngine;

public class EnemyModel
{
    public EnemyTankType EnemyTankType { get; set; }
    public float Speed { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }



    public EnemyModel(EnemyTankScriptableObject enamyTankScriptableObject)
    {
        EnemyTankType = enamyTankScriptableObject.eTankType;
        Speed = enamyTankScriptableObject.Speed;
        Health = enamyTankScriptableObject.Health;
        Damage = enamyTankScriptableObject.Damage;

    }

    public EnemyModel(EnemyTankType eTankType, float speed, float health, float damage)
    {
        Speed = speed;
        Health = health;
        EnemyTankType = eTankType;
        Damage = damage;

    }

}
