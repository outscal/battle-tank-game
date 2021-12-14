using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyView : MonoBehaviour
    {
        public Transform shootPoint;
        private EnemyController enemyController;

        public void setEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
    }
}
