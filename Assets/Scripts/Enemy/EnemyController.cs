using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }

        public EnemyController(EnemyModel model, EnemyView view)
        {
            enemyModel = model;
            enemyView = view;
            enemyModel.setEnemyController(this);
            enemyView.setEnemyController(this);
        }
    }
}
