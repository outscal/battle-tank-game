using UnityEngine;
using Generic;
using System.Collections.Generic;
using System.Collections;
using ScriptableObj;
using Enemy;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        
        public Transform TankParent;
        public List<TankController> Tanks = new List<TankController>();
        public List<TankScriptableObj> TankScriptableObjs;

        private TankView TankPrefab;

        protected override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            for (int i = 0; i < TankScriptableObjs.Count; i++)
            {
                SpawnTank(i);
            }
            
        }

        void SpawnTank(int tankIndex)
        {
            TankModel tankModel = new TankModel(TankScriptableObjs[tankIndex]);
            TankPrefab = tankModel.TankView;
            TankController TankObj = new TankController(tankModel, TankPrefab, TankParent);
            Tanks.Add(TankObj);
        }


        public void DestroyTank(TankController tank)
        {
            tank.KillTank();
            for (int i = 0; i < Tanks.Count; i++)
            {
                if(Tanks[i] == tank)
                {
                    Tanks.Remove(Tanks[i]);
                    break;
                }
            }
            
            tank = null;
            StartCoroutine(Haltgame(0.2f));
            StartCoroutine(EnemyService.Instance.DestroyAllEnemies());
        }


        public IEnumerator Haltgame(float scaleValue)
        {
            Time.timeScale = scaleValue;
            yield return new WaitForSeconds(.5f);

            scaleValue += .2f;
            if (scaleValue < 1)
                StartCoroutine(Haltgame(scaleValue));
        }

    }
}
