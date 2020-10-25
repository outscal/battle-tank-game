using UnityEngine;
using Singleton;

namespace Game
{
    public class CameraController : MonoSingletonGeneric<CameraController>
    {
        Transform target;
        Vector3 diff;
        public void SetTarget(Transform camTarget)
        {
            target = camTarget;
            diff = transform.position - camTarget.position;
        }

        private void Update()
        {
            if (target != null)
            {
                transform.position = target.position + diff;
            }
        }
    }
}
