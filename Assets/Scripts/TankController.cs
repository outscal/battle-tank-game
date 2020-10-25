using UnityEngine;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour
    {
        private FloatingJoystick joystick;
        private float horizontalInput, verticalInput;
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Transform chassis;
        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetupJoystick(FloatingJoystick js)
        {
            joystick = js;
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
            if (horizontalInput != 0 || verticalInput != 0)
            {
                rb.AddForce(chassis.transform.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
        }

        void HandleJoystickInput()
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
            if (horizontalInput != 0 || verticalInput != 0)
            {
                chassis.transform.localEulerAngles = new Vector3(0, (Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg) + 45f, 0);
            }
        }
    }
}
