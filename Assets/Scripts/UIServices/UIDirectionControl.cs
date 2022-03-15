using UnityEngine;

namespace UIServices
{
    public class UIDirectionControl : MonoBehaviour
    {
        public bool b_UseRelativeRotation = true;

        private Quaternion relativeRotaion;

        void Start()
        {
            relativeRotaion = transform.parent.localRotation;
        }

        void Update()
        {
            if (b_UseRelativeRotation)
            {
                transform.rotation = relativeRotaion;
            }
        }
    }
}
