using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MVC.Tank
{
    public class EnemyService : MonoBehaviour
    {
        public EnemyView EnemyView;
        public EnemyScriptableObject[] enemyConfigurations;
        private String x;

        // Use this for initialization
        void Start()
        {
            EnemyScriptableObject enemyScriptableObject = enemyConfigurations[Random.Range(0, 2)];
            EnemyModel model = new EnemyModel(enemyScriptableObject);
            EnemyController enemy = new EnemyController(model, EnemyView);
            x = model.TankName;
        }

        // Update is called once per frame
        void Update()
        {

            Debug.Log(x);
        }
    }
}