using UnityEngine;
using Singleton;

namespace Game
{
    public class CameraController : MonoSingletonGeneric<CameraController>
    {
        Transform target;
        [SerializeField]
        Vector3 diff;
        public void SetTarget(Transform camTarget)
        {
            target = camTarget;
        }

        private void LateUpdate()
        {
            if (target != null)
            {
                transform.position = target.position + diff;
            }
        }
    }
}
