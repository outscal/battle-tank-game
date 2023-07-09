using UnityEngine;

namespace BattleTank.Enemy
{
    [RequireComponent(typeof(EnemyView))]
    public class EnemyState : MonoBehaviour
    {
        protected EnemyView enemyView;

        private void Awake()
        {
            enemyView = GetComponent<EnemyView>();
        }

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        public virtual void Tick() { }
    }
}
