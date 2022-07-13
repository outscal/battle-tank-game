using UnityEngine;

namespace UIServices
{
    // This class is used to make sure world space UI elements such as the health bar face the correct direction.
    public class UIDirectionControl : MonoBehaviour
    {
        public bool b_UseRelativeRotation = true; // Relative rotation should be used for this gameobject?

        private Quaternion relativeRotaion; // The local rotatation at the start of the scene.

        void Start()
        {
            relativeRotaion = transform.parent.localRotation;
        }
    
        void Update()
        {
            if(b_UseRelativeRotation)
            {
                transform.rotation = relativeRotaion;
            }
        }
    }
}
