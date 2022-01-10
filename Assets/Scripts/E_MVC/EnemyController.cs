using UnityEngine;

namespace EnemyTankService
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; set; }
        public EnemyView enemyView { get; set; }
    }
/*    public void Move()
    {
        if (enemyView.playerTransform != null)
        {
            float distance = Vector3.Distance(enemyView.transform.position, enemyView.playerTransform.position);
            if (distance <= enemyModel.followRadius)
            {
                Follow();
            }
            else
            {
                Patrol();
            }
        }*/
    }
