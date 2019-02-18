using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace CameraScripts
{
    public class MiniMapCamera : MonoBehaviour
    {
        private GameObject followTarget;

        public void SetMiniMaptarget(GameObject followTarget)
        {
            this.followTarget = followTarget;
            transform.position = new Vector3(followTarget.transform.position.x, transform.position.y,
                                             followTarget.transform.position.z);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if(followTarget != null)
            {
                transform.position = new Vector3(followTarget.transform.position.x, transform.position.y,
                                                 followTarget.transform.position.z);
            }
        }
    }
}