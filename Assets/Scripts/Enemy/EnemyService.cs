using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;
using ScriptableObj;

namespace Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public Transform EnamyParent;
        public List<EnemyScriptableObj> EnamyScriptableObjs;
        public KeyCode EnemySpawnKey;
        [SerializeField]
        private List<EnemyController> Enemies = new List<EnemyController>();

        protected override void Awake()
        {
            base.Awake();
        }


        private void CheckingForSpawnInput()
        {
            if (Input.GetKeyDown(EnemySpawnKey))
            {
                for (int tankIndex = 0; tankIndex < EnamyScriptableObjs.Count; tankIndex++)
                {
                    SpawnEnamy(tankIndex, GetRandomPos(EnamyScriptableObjs[tankIndex].EnemySpawnPoint1.position,
                                               EnamyScriptableObjs[tankIndex].EnemySpawnPoint2.position));
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
            EnemyController EnemyObj = new EnemyController(enemyModel, enemyModel.EnemyView, EnamyParent, spawnPos);
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
                    break;
                }
            }
            enemyTank = null;

            //SpawnEnemyOnSafePosition();
        }


        private void SpawnEnemyOnSafePosition()
        {
            if (Enemies.Count < 1)
                SpawnEnamy(0, EnamyScriptableObjs[0].EnemySpawnSafe.position);
        }


        public IEnumerator DestroyAllEnemies()
        {
            for (int i = Enemies.Count; i > 0; i--)
            {
                yield return new WaitForSeconds(1f);
                DestroyEnemy(Enemies[0]);
            }
            yield return new WaitForSeconds(1f);
            GameService.Instance.DestroyeAllGameArts();
        }
    }
}


