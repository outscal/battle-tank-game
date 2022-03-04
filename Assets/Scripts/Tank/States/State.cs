using UnityEngine;

namespace Tank.States
{
    [RequireComponent(typeof(TankView))]
    public abstract class State : MonoBehaviour
    {
        protected EnemyTankView _tankView;

        protected void Awake()
        {
            _tankView = GetComponent<EnemyTankView>();
        }
        

        public virtual void Enter()
        {
            this.enabled = true;
        }

        public virtual void Exit()
        {
            this.enabled = false;
        }
    }
}