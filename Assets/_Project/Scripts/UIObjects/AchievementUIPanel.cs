using UnityEngine;

namespace BattleTank.UI
{
    public class AchievementUIPanel : MonoBehaviour
    {
        private Quaternion defaultRotaionAngle;
        private Quaternion displayRotationAngle;

        private bool rotateUIPanelFromLeft;
        private bool rotateUIPanelToRight;

        private int rotationValue;
        private int rotationSpeed;

        private float rotationLimitFromLeft;
        private float rotationLimitToRight;

        private void Awake()
        {
            rotateUIPanelFromLeft = false;
            rotateUIPanelToRight = false;

            defaultRotaionAngle = Quaternion.Euler(new Vector3(0, -90, 0));
            displayRotationAngle = Quaternion.Euler(new Vector3(0, 0, 0));

            rotationValue = 1;
            rotationSpeed = 3;

            rotationLimitFromLeft = 355f;
            rotationLimitToRight = 90f;
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
                    transform.rotation = defaultRotaionAngle;
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