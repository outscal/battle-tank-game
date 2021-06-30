using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
    public class PatrolAction : Action
    {
        [System.Obsolete]
        public override void act(StateController controler)
        {
            Patrol(controler);
        }

        [System.Obsolete]
        private void Patrol(StateController controller)
        {
            controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;
            controller.navMeshAgent.Resume();

            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
            }
        }
    }
}