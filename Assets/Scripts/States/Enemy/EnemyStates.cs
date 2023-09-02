using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.tank
{
    [RequireComponent(typeof(EnemyView))]
    public class EnemyStates : MonoBehaviour 
    {
        [SerializeField]
        protected EnemyView _EnemyView;
        protected EnemyController _EnemyController;
        private void Awake()
        {
            Debug.Log("Enemystates");
            _EnemyView = GetComponent<EnemyView>();
            Debug.Log(_EnemyView.gameObject.name);
            _EnemyController=_EnemyView.GetEnemyController();
        }

        public virtual void OnEnterState() 
        {
            Debug.Log("On enter state :" + this._EnemyView.name);
            this.enabled = true;
        }
        public virtual void OnExitState() 
        {
            this.enabled = false;
        }
        public virtual void OnUpdateState() { }

        public virtual Enemystate GetState()
        {
            return Enemystate.None;      
        }

    }
}

