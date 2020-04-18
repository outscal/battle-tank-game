using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Enemy;

public class HealthService : MonoSingletonGeneric<HealthService>
{
    

    public void DeductEnemyHealth(EnemyView enemy, float damage)
    {
        //enemy.GetController().TakeDamage(enemy, damage);
    }

    public void DeductPlayerHealth(TankView tank, float damage)
    {
        //tank.GetController().TakeDamage(tank, damage);
    }

}   


