using UnityEngine;

namespace BattleTank.UI
{
    public class AchievementUIPanel : MonoBehaviour
    {
        private Quaternion defaultRotationAngle;
        private Quaternion displayRotationAngle;

        [SerializeField] private Vector3 newDefaultRotation;

        [SerializeField] private bool rotateUIPanelFromLeft;
        [SerializeField] private bool rotateUIPanelToRight;

        [SerializeField] private int rotationValue;
        [SerializeField] private int rotationSpeed;

        [SerializeField] private float rotationLimitFromLeft;
        [SerializeField] private float rotationLimitToRight;

        private void Awake()
        {
            defaultRotationAngle = Quaternion.Euler(newDefaultRotation);
            displayRotationAngle = Quaternion.Euler(Vector3.zero);
        }

        private void Update()
        {
            if(rotateUIPanelFromLeft == true)
            {
                gameObject.transform.Rotate(Vector3.up, rotationValue * rotationSpeed);
                 
                if(transform.rotation.eulerAngles.y > rotationLimitFromLeft)
                {
                    rotateUIPanelFromLeft = false;
                    transform.rotation = displayRotationAngle;
                }
            }

            if (rotateUIPanelToRight == true)
            {
                gameObject.transform.Rotate(Vector3.up, rotationValue * rotationSpeed);

                if (transform.rotation.eulerAngles.y > rotationLimitToRight)
                {
                    rotateUIPanelToRight = false;
                    transform.rotation = defaultRotationAngle;
                }
            }
        }

        public void StartIntro(bool _value)
        {
            rotateUIPanelFromLeft = _value;
        }

        public void StartOutro(bool _value)
        {
            rotateUIPanelToRight = _value;
        }
    }
}