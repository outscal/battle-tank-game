using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.tank
{
    public class EnemyStates : MonoBehaviour 
    {
        protected EnemyView _EnemyView;
        protected EnemyController _EnemyController;
        private void Start()
        {
            _EnemyView = GetComponent<EnemyView>();
            _EnemyController = _EnemyView.GetEnemyController();
        }
        public virtual void OnEnterState() { }
        public virtual void OnExitState() { }
        public virtual void OnUpdateState() { }

        public virtual Enemystate GetState()
        {
            return Enemystate.None;      
        }

    }
}

