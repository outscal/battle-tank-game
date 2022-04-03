using UnityEngine;

namespace EnemyTankServices
{
    [RequireComponent(typeof(EnemyTankView))]
    public class EnemyStates : MonoBehaviour
    {
        protected EnemyTankView tankView;
        protected EnemyTankModel tankModel;

        protected virtual void Awake()
        {
            tankView = GetComponent<EnemyTankView>();         
        }

        protected virtual void Start()
        {
            tankModel = tankView.tankController.tankModel;
        }

        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        public void ChangeState(EnemyStates newState)
        {
            if (tankView.currentState != null)
            {
                tankView.currentState.OnStateExit();
            }

            tankView.currentState = newState;
            tankView.currentState.OnStateEnter();
        }
    }
}
