using UnityEngine;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour
    {
        private FloatingJoystick leftJoystick,rightJoystick;
        private float horizontalInputLeft, verticalInputLeft, horizontalInputRight, verticalInputRight;
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Transform chassis,turret;
        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetupJoysticks(FloatingJoystick leftjs, FloatingJoystick rightjs)
        {
            leftJoystick = leftjs;
            rightJoystick = rightjs;
        }

        private void FixedUpdate()
        {
            HandlePlayerInput();
        }

        private void Update()
        {
            HandleJoystickInput();
        }

        private void HandlePlayerInput()
        {
            if (horizontalInputLeft != 0 || verticalInputLeft != 0)
            {
                rb.AddForce(chassis.transform.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
        }

        void HandleJoystickInput()
        {
            horizontalInputLeft = leftJoystick.Horizontal;
            verticalInputLeft = leftJoystick.Vertical;
            if (horizontalInputLeft != 0 || verticalInputLeft != 0)
            {
                chassis.transform.localEulerAngles = new Vector3(0, (Mathf.Atan2(horizontalInputLeft, verticalInputLeft) * Mathf.Rad2Deg) + 45f, 0);
            }
            horizontalInputRight = rightJoystick.Horizontal;
            verticalInputRight = rightJoystick.Vertical;
            if (horizontalInputRight != 0 || verticalInputRight != 0)
            {
                turret.transform.localEulerAngles = new Vector3(0, (Mathf.Atan2(horizontalInputRight, verticalInputRight) * Mathf.Rad2Deg) + 45f, 0);
            }
        }
    }
}
