using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;

namespace Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public Transform EnamyParent;
        public List<EnemyController> Enemies = new List<EnemyController>();
        public List<EnemyScriptableObj> EnamyScriptableObjs;
        public KeyCode EnemySpawnKey;

        private EnemyView EnamyPrafab;

        protected override void Awake()
        {
            base.Awake();
        }


        private void CheckingForSpawnInput()
        {
            if (Input.GetKeyDown(EnemySpawnKey))
            {
                for (int i = 0; i < EnamyScriptableObjs.Count; i++)
                {
                    SpawnEnamy(i, GetRandomPos(EnamyScriptableObjs[i].EnemySpawnPoint1.position,
                                               EnamyScriptableObjs[i].EnemySpawnPoint2.position));
                }
            }

        }


        private void Update()
        {
            CheckingForSpawnInput();
        }


        void SpawnEnamy(int enemyIndex, Vector3 spawnPos)
        {
            EnemyModel enemyModel = new EnemyModel(EnamyScriptableObjs[enemyIndex]);
            EnamyPrafab = enemyModel.M_EnemyView;
            EnemyController EnemyObj = new EnemyController(enemyModel, EnamyPrafab, EnamyParent, spawnPos);
            Enemies.Add(EnemyObj);
        }


        private Vector3 GetRandomPos(Vector3 enemySpawnPoint1, Vector3 enemySpawnPoint2)
        {
            float X_Pos = Random.Range(enemySpawnPoint1.x,
                enemySpawnPoint2.x);
            float Z_Pos = Random.Range(enemySpawnPoint1.z,
                enemySpawnPoint2.z);

            Vector3 randomPos = new Vector3(X_Pos, 0, Z_Pos);
            return randomPos;
        }


        public void DestroyEnemy(EnemyController enemyTank)
        {
            enemyTank.KillTank();
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i] == enemyTank)
                {
                    Enemies.Remove(Enemies[i]);
                }
            }
            enemyTank = null;

            SpawnEnemyOnSafePosition();
        }


        private void SpawnEnemyOnSafePosition()
        {
            if (Enemies.Count < 1)
                SpawnEnamy(0, EnamyScriptableObjs[0].EnemySpawnSafe.position);
        }
    }
}


