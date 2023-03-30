using UnityEngine;

namespace BattleTank
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        
        public Rigidbody GetRigidBody()
        {
            return rb;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IDamageable>() != null)
            {
                IDamageable damageableObject = other.GetComponent<IDamageable>();
                damageableObject.Damage(bulletController.GetDamage());
            }
            DestroyGameObject();
        }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}