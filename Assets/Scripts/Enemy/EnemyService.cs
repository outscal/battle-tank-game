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


        private void Start()
        {
        }

        private void CheckingForSpawnInput()
        {
            if(Input.GetKeyDown(EnemySpawnKey))
            {
                for (int i = 0; i < EnamyScriptableObjs.Count; i++)
                {
                    SpawnEnamy(i);
                }
            }

        }

        private void Update()
        {
            CheckingForSpawnInput();
        }


        void SpawnEnamy(int enemyIndex)
        {
            EnemyModel enemyModel = new EnemyModel(EnamyScriptableObjs[enemyIndex]);
            EnamyPrafab = enemyModel.M_EnemyView;
            EnemyController EnemyObj = new EnemyController(enemyModel, EnamyPrafab, EnamyParent);
            Enemies.Add(EnemyObj);
            //Debug.Log("M_Health " + enemyModel.M_Health);
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
        }

    }
}


