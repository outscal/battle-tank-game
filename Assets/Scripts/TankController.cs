using UnityEngine;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankController : MonoBehaviour
    {
        [SerializeField]
        protected Transform chassis, turret;
        private Rigidbody rb;
        [SerializeField]
        private float moveSpeed,bulletSpeed;

        [SerializeField]
        private int health, bulletDamage;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected void MoveTankForward()
        {
            rb.AddForce(chassis.transform.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        
    }
}
