using UnityEngine;

namespace TankBattle.TankService.PlayerTank
{
    [RequireComponent(typeof(Rigidbody))]

    public class TankView : MonoBehaviour
    {
        private Rigidbody rb;

        [SerializeField] private float speed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetSpeed(float _speed)
        {
            speed = _speed;
        }

        public Rigidbody GetRigidbody()
        {
            return rb;
        }
    }
}