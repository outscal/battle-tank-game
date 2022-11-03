using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Tank
{
    public class TankState : MonoBehaviour
    {
        protected EnemyView enemyView;
        private void Awake()
        {
            enemyView = GetComponent<EnemyView>();
        }
        public virtual void OnEnterState()
        {
            this.enabled = true ;
        }
        public virtual void OnExitState()
        {
            this.enabled = false;
        }
    }
}


