using UnityEngine;

namespace TankBattle.Tank
{
    // not exactly sure of function of the relativeRotation here. 
    // As the HealthSlider is aligned correctly most of the times with its parent tank obj
    public class UIDirectionControl : MonoBehaviour
    {
        private bool useRelativeRotation = true;

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
