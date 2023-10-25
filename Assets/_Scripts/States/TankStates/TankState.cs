using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [RequireComponent(typeof(TankView))]
    public class TankState : MonoBehaviour
    {
        protected TankView tankView;

        [SerializeField]
        protected Color color;

        protected virtual void Awake()
        {
            tankView = GetComponent<TankView>();
        }
        public virtual void OnEnterState()
        {
            this.enabled = true;
        }
        public virtual void OnExitState()
        {
            this.enabled = false;
        }

        //
        //public virtual void Tick() { } //similar to update fn

    }
}