using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;

namespace Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {

        public Transform EnamyParent;
        public List<EnemyController> Enamies = new List<EnemyController>();
        public List<EnemyScriptableObj> EnamyScriptableObjs;

        private EnemyView EnamyPrafab;

        protected override void Awake()
        {
            base.Awake();
        }


        private void Start()
        {
            for (int i = 0; i < EnamyScriptableObjs.Count; i++)
            {
                SpawnEnamy(i);
            }
        }


        void SpawnEnamy(int enamyIndex)
        {
            //EnamyModel enamyModel = new EnamyModel(EnamyScriptableObjs[enamyIndex]);
            //EnamyPrafab = enamyModel.M_EnamyView;
            //EnamyController EnamyObj = new EnamyController(enamyModel, EnamyPrafab, EnamyParent);
            //Enamies.Add(EnamyObj);
        }

    }
}


