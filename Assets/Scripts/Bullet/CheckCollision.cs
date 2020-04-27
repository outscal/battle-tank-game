using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;
using TankGame.Enemy;
using TankGame.Tank;


public class CheckCollision : BulletView
{

    //public CheckCollision(Collision collision, float damage)
    //{
    //    BulletController controller = GetController();
    //    Collider[] colliders = Physics.OverlapSphere(collision.transform.position, 5f);
    //    foreach (Collider hit in colliders)
    //    {
    //        if (hit.GetComponent<EnemyView>())
    //        {
    //            EnemyView enemy = hit.GetComponent<EnemyView>();
    //            if (enemy != null)
    //            {
    //                //enemy.ApplyDamage(damage);
    //                //EnemyTankType enemyType =  enemy.tankType;
    //                controller.ApplyDamage(damage, enemy);
    //            }
    //        }
    //        else
    //        {
    //            if (hit.GetComponent<TankView>())
    //            {
    //                TankView tank = hit.GetComponent<TankView>();
    //                if (tank != null)
    //                {
    //                    //PlayerTankView playerType = tank.
    //                    Debug.Log("player is hit");
    //                }
    //            }
    //        }
    //    }

    //    controller.DestroyBulletView(this);
    // }

}
