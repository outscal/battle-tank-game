using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class UIDirectionControl : MonoBehaviour
    {
        public bool useRelativeRotation = true;

        private Quaternion relativeRotation;

        private void Start()
        {
            relativeRotation = transform.parent.localRotation;
        }
        private void Update()
        {
            if(useRelativeRotation)
            {
                transform.rotation = relativeRotation;
            }
        }
    }
}
