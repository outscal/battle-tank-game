using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class EnemyController 
    {

        public EnemyController(EnemyModel enemyModel, EnemyView tankPrefab)
        {
            EnemyModel = enemyModel;
            EnemyView = Object.Instantiate(tankPrefab);
            Debug.Log("Enemy Controller created");
        }

        public EnemyModel EnemyModel { get; }
        public EnemyView EnemyView { get; }
    }
}