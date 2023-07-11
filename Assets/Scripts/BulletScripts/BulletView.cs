using UnityEngine;

namespace BattleTank.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;

        [SerializeField] Rigidbody rb;

        void Start()
        {
            bulletController.Shoot();
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        public TankType GetTankType()
        {
            return bulletController.GetTankType();
        }

        public Rigidbody GetRigidbody()
        {
            return rb;
        }

        void OnCollisionEnter(Collision col)
        {
            bulletController.BulletCollision(col.contacts[0].point);

            IDamageable target = col.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(bulletController.GetBulletDamage(), bulletController.GetTankType());
            }
        }
    }
}
