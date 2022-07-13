using UnityEngine;

namespace EnemyTankServices
{
    // Template class for creating different states of enemy tank. // Implementation of state machine.
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

        // Called when entered in the state // Enables the behaviour of that state. 
        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }

        // Called when exited from the state // Disables the behaviour of that state.
        public virtual void OnStateExit()
        {
            this.enabled = false;
        }

        // To change enemy tank state from current to new state.
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
